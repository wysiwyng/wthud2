﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WtLogging;
using WtTelemetry;

namespace WtHud2
{
    public partial class ConfigForm : Form
    {
        private BindingSource activeParamsBs = new BindingSource();
        private BindingSource availableParamsBs = new BindingSource();

        private List<string> paramIdToName = new List<string>();

        private HUDForm hudForm = new HUDForm();

        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        private string currentCraftName = "";
        private bool prevDataValid = false;

        public ConfigForm()
        {
            InitializeComponent();
        }

        private async Task UpdateHud(CancellationToken cancellationToken)
        {
            while (true)
            {
                var text = "";
                var obj = await Telemetry.GetFlightData();
                int delay = 1000;

                if (obj != null && obj["type"] != "dummy_plane")
                {
                    if (!prevDataValid)
                    {
                        currentCraftName = obj["type"];

                        prevDataValid = true;
                        CurrentCraftNameLbl.Text = currentCraftName;
                        CurrentCraftNameLbl.ForeColor = System.Drawing.Color.DarkGreen;
                        ReloadBtn.Enabled = true;
                        LoadBtn.Enabled = true;

                        LogEntriesLbl.Text = "0";
                        LogFileSizeLbl.Text = "0 kb";

                        await ReloadParams();
                        LoadSavedConfig();

                        if (LoggingEnableChkBox.Checked)
                        {
                            StartLogging();
                        }
                        else
                        {
                            LogFileNameLbl.Text = "Logging not active";
                        }
                    }

                    if (LoggingEnableChkBox.Checked)
                    {
                        var loggingDict = new Dictionary<byte, float>();

                        byte id = 0;
                        foreach (var item in paramIdToName)
                        {
                            if ((activeParamsBs.Contains(new ParamDescription(item)) && LogShownRB.Checked) || LogAllRB.Checked)
                            {
                                if (float.TryParse(obj[item], NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
                                    loggingDict.Add(id, value);
                            }
                            id++;
                        }

                        LogWriter.AddRecord(ref loggingDict);

                        LogEntriesLbl.Text = LogWriter.NumEntries.ToString();
                        LogFileSizeLbl.Text = $"{LogWriter.FileSize / 1024} kb";
                    }

                    foreach (ParamDescription item in activeParamsBs)
                    {
                        if (!obj.ContainsKey(item.Name)) continue;

                        try
                        {
                            var formatString = $"{{0,{item.Format}}}";

                            var temp = $"{item.Description,-6}";
                            temp += String.Format(CultureInfo.InvariantCulture, formatString, double.Parse(obj[item.Name], CultureInfo.InvariantCulture));
                            temp += " " + item.Unit + "\n";

                            text += temp;
                        }
                        catch (FormatException)
                        {
                            text += $"{item.Description,-6} Bad format string\n";
                        }
                    }

                    delay = 100;
                }
                else
                {
                    if (prevDataValid)
                    {
                        LogShownRB.Enabled = true;
                        LogAllRB.Enabled = true;

                        prevDataValid = false;
                        ReloadBtn.Enabled = false;
                        LoadBtn.Enabled = false;
                        CurrentCraftNameLbl.ForeColor = System.Drawing.Color.DarkRed;

                        LogWriter.FinalizeLog();
                    }
                }

                hudForm.HUDLabel.Text = text;

                Task waitTask = Task.Delay(delay, cancellationToken);
                try
                {
                    await waitTask;
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }

        }

        private void StartLogging()
        {
            var logFileName = $"{currentCraftName}_{DateTime.Now:HHmmss_yyMMdd}_log.dat";
            var logFilePath = Path.Combine(GetLogFilePath(currentCraftName));
            LogWriter.StartNewLog(logFilePath);
            LogWriter.WriteHeader(currentCraftName, ref paramIdToName);
            LogFileNameLbl.Text = logFileName;
          
            LogShownRB.Enabled = false;
            LogAllRB.Enabled = false;
        }

        #region GUI functions

        private async Task ReloadParams()
        {
            var obj = await Telemetry.GetFlightData();

            if (obj == null) return;

            activeParamsBs.Clear();
            availableParamsBs.Clear();
            paramIdToName.Clear();

            foreach (var item in obj)
            {
                availableParamsBs.Add(new ParamDescription(item.Key));
                paramIdToName.Add(item.Key);
            }
        }

        private void MoveRow(int amount)
        {
            var selectedIdx = ActiveParamsDGV.SelectedRows[0].Index;
            var newIdx = selectedIdx + amount;

            var item = activeParamsBs[selectedIdx];

            if (newIdx < 0) newIdx = activeParamsBs.Count - 1;
            if (newIdx >= activeParamsBs.Count) newIdx = 0;

            activeParamsBs.RemoveAt(selectedIdx);
            activeParamsBs.Insert(newIdx, item);

            ActiveParamsDGV.Rows[newIdx].Selected = true;
        }

        #endregion

        #region Config file handling

        private string GetLogFilePath(string craftName)
        {
            var fileName = $"{craftName}_{DateTime.Now:HHmmss_yyMMdd}_log.dat";
            var exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            return Path.Combine(exeDir, "logs", fileName);
        }

        private string GetConfigFilePath(string craftName)
        {
            var fileName = $"{craftName}_hud.json";
            var exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            return Path.Combine(exeDir, "configs", fileName);
        }

        private void LoadSavedConfig()
        {
            if (LoadSavedConfig(currentCraftName)) return;
            if (LoadSavedConfig("default")) return;

            MessageBox.Show("Default config not found, please check your installation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool LoadSavedConfig(string craftName)
        {
            var filePath = GetConfigFilePath(craftName);

            if (!File.Exists(filePath)) return false;

            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            List<ParamDescription> paramList;

            using (var sr = new StreamReader(filePath))
            using (var reader = new JsonTextReader(sr))
            {
                paramList = serializer.Deserialize<List<ParamDescription>>(reader);
            }

            foreach (var item in paramList)
            {
                if (availableParamsBs.Contains(item))
                {
                    availableParamsBs.Remove(item);
                    activeParamsBs.Add(item);
                }
            }

            ConfigNameLbl.Text = craftName + "_hud.json";
            return true;
        }

        private void SaveConfig(string craftName)
        {
            var paramList = activeParamsBs.List;

            var filePath = GetConfigFilePath(craftName);

            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, paramList);
            }

            ConfigNameLbl.Text = craftName + "_hud.json";
        }

        #endregion

        #region GUI Event Handlers

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            XPosSpinner.Value = Properties.Settings.Default.HudXPos;
            YPosSpinner.Value = Properties.Settings.Default.HudYPos;

            hudForm.Show();
            hudForm.SetDesktopLocation((int)XPosSpinner.Value, (int)YPosSpinner.Value);

            activeParamsBs.DataSource = typeof(ParamDescription);

            ActiveParamsDGV.DataSource = activeParamsBs;
            ActiveParamsDGV.AutoGenerateColumns = true;

            availableParamsBs.DataSource = typeof(ParamDescription);

            AvailableParamsLB.DataSource = availableParamsBs;
            AvailableParamsLB.DisplayMember = "Name";

            _ = UpdateHud(tokenSource.Token);

            availableParamsBs.ListChanged += AvailableParamsBs_ListChanged;
            activeParamsBs.ListChanged += ActiveParamsBs_ListChanged;
        }

        private void ActiveParamsBs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (activeParamsBs.Count == 0)
            {
                UpBtn.Enabled = false;
                DnBtn.Enabled = false;
                RemBtn.Enabled = false;
                SaveBtn.Enabled = false;
            }
            else
            {
                UpBtn.Enabled = true;
                DnBtn.Enabled = true;
                RemBtn.Enabled = true;
                SaveBtn.Enabled = true;
            }
        }

        private void AvailableParamsBs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (availableParamsBs.Count == 0)
            {
                AddBtn.Enabled = false;
                RemBtn.Enabled = false;
            }
            else
            {
                AddBtn.Enabled = true;
            }
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.HudXPos = (int)XPosSpinner.Value;
            Properties.Settings.Default.HudYPos = (int)YPosSpinner.Value;
            Properties.Settings.Default.Save();
        }

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            _ = ReloadParams();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var selectedParam = (ParamDescription)AvailableParamsLB.SelectedItem;

            activeParamsBs.Add(selectedParam);
            availableParamsBs.Remove(selectedParam);
        }

        private void RemBtn_Click(object sender, EventArgs e)
        {
            var selectedParam = (ParamDescription)ActiveParamsDGV.SelectedRows[0].DataBoundItem;

            availableParamsBs.Add(selectedParam);
            activeParamsBs.Remove(selectedParam);
        }

        private void XPosSpinner_ValueChanged(object sender, EventArgs e)
        {
            hudForm.SetDesktopLocation((int)XPosSpinner.Value, (int)YPosSpinner.Value);
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            MoveRow(-1);
        }

        private void DnBtn_Click(object sender, EventArgs e)
        {
            MoveRow(1);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveConfig(currentCraftName);
        }

        private async void LoadBtn_Click(object sender, EventArgs e)
        {
            await ReloadParams();
            LoadSavedConfig();
        }

        private void HUDFontBtn_Click(object sender, EventArgs e)
        {
            var dlg = new FontDialog
            {
                ShowColor = true,
                ShowEffects = true,
                Font = hudForm.HUDLabel.Font,
                Color = hudForm.HUDLabel.ForeColor
            };

            var result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                hudForm.HUDLabel.Font = dlg.Font;
                hudForm.HUDLabel.ForeColor = dlg.Color;

                Properties.Settings.Default.HudTextFont = dlg.Font;
                Properties.Settings.Default.HudTextColor = dlg.Color;
            }
        }

        private void LoggingEnableChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LoggingEnableChkBox.Checked)
            {
                if (prevDataValid)
                {
                    StartLogging();
                }
            }
            else
            {
                LogWriter.FinalizeLog();
            }
        }

        #endregion
    }
}
