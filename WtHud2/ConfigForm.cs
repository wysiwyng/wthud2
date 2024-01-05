using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WtLogging;
using WtTelemetry;

namespace WtHud2
{
    public partial class ConfigForm : Form
    {
        private const string separatorName = "-SEPARATOR-";

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
            try
            {
                while (true)
                {
                    StringBuilder textsb = new StringBuilder();
                    Dictionary<string, string> obj = await Telemetry.GetFlightData();
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
                            Dictionary<byte, float> loggingDict = new Dictionary<byte, float>();

                            byte id = 0;
                            foreach (string item in paramIdToName)
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
                            if (!obj.ContainsKey(item.Name))
                            {
                                if (item.Name.Equals(separatorName))
                                    textsb.AppendLine();
                                continue;
                            }

                            try
                            {    
                                string formatString = $"{{0,{item.Format}}}";

                                string value = string.Format(CultureInfo.InvariantCulture, formatString, double.Parse(obj[item.Name], CultureInfo.InvariantCulture));

                                string line = string.Format(CultureInfo.InvariantCulture,
                                    "{0, -6}{1} {2}", item.Description, value, item.Unit );

                                textsb.AppendLine(line);

                            }
                            catch (FormatException)
                            {
                                textsb.AppendLine($"{item.Description,-6} Bad format string");
                            }
                        }

                        delay = Properties.Settings.Default.RefreshRate;
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

                    hudForm.HUDLabel.Text = textsb.ToString();

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
            catch (Exception)
            {
                MessageBox.Show("Hud update task exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartLogging()
        {
            string logFileName = $"{currentCraftName}_{DateTime.Now:HHmmss_yyMMdd}_log.dat";
            string logFilePath = Path.Combine(GetLogFilePath(currentCraftName));
            LogWriter.StartNewLog(logFilePath);
            LogWriter.WriteHeader(currentCraftName, ref paramIdToName);
            LogFileNameLbl.Text = logFileName;

            LogShownRB.Enabled = false;
            LogAllRB.Enabled = false;
        }

        #region GUI functions

        private async Task ReloadParams()
        {
            Dictionary<string, string> obj = await Telemetry.GetFlightData();

            if (obj == null) return;

            activeParamsBs.Clear();
            availableParamsBs.Clear();
            paramIdToName.Clear();


            availableParamsBs.Add(new ParamDescription(separatorName, "", "", ""));

            foreach (KeyValuePair<string, string> item in obj)
            {
                availableParamsBs.Add(new ParamDescription(item.Key));
                paramIdToName.Add(item.Key);
            }
        }

        private void MoveRow(int amount)
        {
            int selectedIdx = ActiveParamsDGV.SelectedRows[0].Index;
            int newIdx = selectedIdx + amount;

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
            string fileName = $"{craftName}_{DateTime.Now:HHmmss_yyMMdd}_log.dat";
            string exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            return Path.Combine(exeDir, "logs", fileName);
        }

        private string GetConfigFilePath(string craftName)
        {
            string fileName = $"{craftName}_hud.json";
            string exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

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
            string filePath = GetConfigFilePath(craftName);

            if (!File.Exists(filePath)) return false;

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            List<ParamDescription> paramList;

            using (StreamReader sr = new StreamReader(filePath))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                paramList = serializer.Deserialize<List<ParamDescription>>(reader);
            }

            foreach (ParamDescription item in paramList)
            {
                if (availableParamsBs.Contains(item))
                {
                    if (item.Name != separatorName)
                    {
                        availableParamsBs.Remove(item);
                    }

                    activeParamsBs.Add(item);
                }
            }

            ConfigNameLbl.Text = craftName + "_hud.json";
            return true;
        }

        private void SaveConfig(string craftName)
        {
            var paramList = activeParamsBs.List;

            string filePath = GetConfigFilePath(craftName);

            JsonSerializer serializer = new JsonSerializer
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
            hudForm.HUDLabel.Font = Properties.Settings.Default.HudTextFont;
            hudForm.HUDLabel.ForeColor = Properties.Settings.Default.HudTextColor;

            XPosSpinner.Value = Properties.Settings.Default.HudXPos;
            YPosSpinner.Value = Properties.Settings.Default.HudYPos;

            RefreshRateSpinner.Value = Properties.Settings.Default.RefreshRate;

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
            ParamDescription selectedParam = (ParamDescription)AvailableParamsLB.SelectedItem;

            // do not remove separator item
            if (!selectedParam.Name.Equals(separatorName))
                availableParamsBs.Remove(selectedParam);

            // add after selected line, if possible
            if (ActiveParamsDGV.SelectedRows.Count > 0)
            {
                int index = ActiveParamsDGV.SelectedRows[0].Index;

                if (index < ActiveParamsDGV.RowCount)
                {
                    activeParamsBs.Insert(index + 1, selectedParam);

                    //select what we just added
                    ActiveParamsDGV.Rows[index + 1].Selected = true;
                    return;
                }
            }
            // selected line is none, or last


            activeParamsBs.Add(selectedParam);
            //select what we just added
            ActiveParamsDGV.Rows[ActiveParamsDGV.Rows.Count - 1].Selected = true;
        }


        private void RemBtn_Click(object sender, EventArgs e)
        {
            if (ActiveParamsDGV.SelectedRows.Count == 0)
                return;

            int index = ActiveParamsDGV.SelectedRows[0].Index;
            ParamDescription selectedParam = (ParamDescription)ActiveParamsDGV.Rows[index].DataBoundItem;

            if (!selectedParam.Name.Equals(separatorName))
                availableParamsBs.Add(selectedParam);

            activeParamsBs.Remove(selectedParam);

            //select next, or last item in list, to be ready to next [<-] button click
            if (ActiveParamsDGV.Rows.Count > 0)
                ActiveParamsDGV.Rows[Math.Min(index, ActiveParamsDGV.Rows.Count - 1)].Selected = true;
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
            FontDialog dlg = new FontDialog
            {
                ShowColor = true,
                ShowEffects = true,
                ShowApply = true,

                Font = hudForm.HUDLabel.Font,
                Color = hudForm.HUDLabel.ForeColor,
            };
            dlg.Apply += Dlg_Apply;


            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
                Dlg_Apply(dlg, e);

            dlg.Dispose();
        }

        private void Dlg_Apply(object sender, EventArgs e)
        {
            FontDialog fd = sender as FontDialog;

            hudForm.HUDLabel.Font = fd.Font;
            hudForm.HUDLabel.ForeColor = fd.Color;

            Properties.Settings.Default.HudTextFont = fd.Font;
            Properties.Settings.Default.HudTextColor = fd.Color;
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

        private void AvailableParamsLB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddBtn_Click(sender, e);
        }

        private void HUDColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog
            {
                SolidColorOnly = true,
                Color = hudForm.HUDLabel.ForeColor,
            };

            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                hudForm.HUDLabel.ForeColor = dlg.Color;
                Properties.Settings.Default.HudTextColor = dlg.Color;
            }
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string path = Path.Combine(exeDir, "configs");

            System.Diagnostics.Process.Start(path);
        }

        #endregion

        private void RefreshRateSpinner_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RefreshRate = (int)RefreshRateSpinner.Value;
        }
    }
}
