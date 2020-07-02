using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WtTelemetry;

namespace WtHud2
{
    public partial class ConfigForm : Form
    {
        private BindingSource activeParamsBs = new BindingSource();
        private BindingSource availableParamsBs = new BindingSource();

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

                if (obj != null)
                {
                    if (!prevDataValid)
                    {
                        prevDataValid = true;
                        currentCraftName = obj["type"];
                        ReloadBtn.Enabled = true;
                        SaveBtn.Enabled = true;
                        LoadBtn.Enabled = true;
                        await ReloadParams();
                        LoadSavedConfig();
                    }

                    foreach (ParamDescription item in activeParamsBs)
                    {
                        if (!obj.ContainsKey(item.Name)) continue;

                        var formatString = $"{{0,{item.Format}}}";

                        text += $"{item.Description,-6}";
                        text += String.Format(CultureInfo.InvariantCulture, formatString, double.Parse(obj[item.Name], CultureInfo.InvariantCulture));
                        text += " " + item.Unit + "\n";
                    }

                    delay = 100;
                }
                else
                {
                    prevDataValid = false;
                    ReloadBtn.Enabled = false;
                    SaveBtn.Enabled = false;
                    LoadBtn.Enabled = false;
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

        #region GUI functions

        private async Task ReloadParams()
        {
            var obj = await Telemetry.GetFlightData();

            activeParamsBs.Clear();
            availableParamsBs.Clear();

            foreach (var item in obj)
            {
                availableParamsBs.Add(new ParamDescription(item.Key));
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

            var serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;

            List<ParamDescription> paramList;

            using (var sr = new StreamReader(filePath))
            using (var reader = new JsonTextReader(sr))
            {
                paramList = serializer.Deserialize<List<ParamDescription>>(reader);
            }

            foreach (var item in paramList)
            {
                activeParamsBs.Add(item);
                if (availableParamsBs.Contains(item))
                {
                    availableParamsBs.Remove(item);
                }
            }

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

        private void LoadBtn_Click(object sender, EventArgs e)
        {
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

            hudForm.HUDLabel.Font = dlg.Font;
            hudForm.HUDLabel.ForeColor = dlg.Color;

            Properties.Settings.Default.HudTextFont = dlg.Font;
            Properties.Settings.Default.HudTextColor = dlg.Color;
        }

        #endregion
    }
}
