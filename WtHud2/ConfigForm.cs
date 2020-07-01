using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WtTelemetry;

namespace wthud3
{
    public partial class ConfigForm : Form
    {
        private BindingSource activeParamsBs = new BindingSource();
        private BindingSource availableParamsBs = new BindingSource();

        private HUDForm hudForm = new HUDForm();

        private CancellationTokenSource tokenSource = new CancellationTokenSource();

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
                    foreach (ParamDescription item in activeParamsBs)
                    {
                        text += $"{item.Description,-6}";
                        text += String.Format(CultureInfo.InvariantCulture, item.Format, double.Parse(obj[item.Key], CultureInfo.InvariantCulture));
                        //text += double.Parse(obj[item.Key], CultureInfo.InvariantCulture).ToString(item.Format, CultureInfo.InvariantCulture);
                        text += " " + item.Unit + "\n";
                    }

                    delay = 100;                    
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

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            hudForm.Show();
            hudForm.SetDesktopLocation((int)XPosSpinner.Value, (int)YPosSpinner.Value);

            activeParamsBs.DataSource = typeof(ParamDescription);

            ActiveParamsDGV.DataSource = activeParamsBs;
            ActiveParamsDGV.AutoGenerateColumns = true;

            availableParamsBs.DataSource = typeof(ParamDescription);

            AvailableParamsLB.DataSource = availableParamsBs;
            AvailableParamsLB.DisplayMember = "Key";

            _ = UpdateHud(tokenSource.Token);
        }

        private async void ReloadBtn_Click(object sender, EventArgs e)
        {
            var obj = await Telemetry.GetFlightData();

            activeParamsBs.Clear();
            availableParamsBs.Clear();

            foreach (var item in obj)
            {
                availableParamsBs.Add(new ParamDescription(item.Key, item.Key, "", "{0,7:F1}"));
            }
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

        private void UpBtn_Click(object sender, EventArgs e)
        {
            MoveRow(-1);
        }

        private void DnBtn_Click(object sender, EventArgs e)
        {
            MoveRow(1);
        }
    }
}
