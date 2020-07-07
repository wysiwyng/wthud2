using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Windows.Forms;
using WtLogging;

namespace LogView
{
    public partial class LogView : Form
    {
        private BindingSource logDataBs = new BindingSource();

        private PlotModel pm = new PlotModel();

        public LogView()
        {
            InitializeComponent();
        }

        private void LoadLogBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            var res = dlg.ShowDialog();

            if (res != DialogResult.OK) return;

            LogReader.ReadLog(dlg.FileName);

            logDataBs.Clear();
            foreach (var item in LogReader.IdToName)
            {
                logDataBs.Add(new LogParamDescription(item, LogReader.LogTable[item]));
            }

            pm.Series.Clear();
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            logDataBs.DataSource = typeof(LogParamDescription);

            //logDataBs.Add(new LogParamDescription() { Enabled = true, ParamName = "test" });

            PlotConfigDGV.DataSource = logDataBs;
            PlotConfigDGV.AutoGenerateColumns = true;

            PlotConfigDGV.Columns[0].Width = 30;

            logDataBs.ListChanged += LogDataBs_ListChanged;

            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time, s", MajorGridlineStyle = LineStyle.Solid });
            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Value", MajorGridlineStyle = LineStyle.Solid });

            plotView1.Model = pm;
        }

        private void LogDataBs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType != System.ComponentModel.ListChangedType.ItemChanged) return;

            var changedIdx = e.NewIndex;

            var selectedItem = (LogParamDescription) logDataBs[changedIdx];

            if (selectedItem.Enabled)
            {
                pm.Series.Add(selectedItem.Data);
            }
            else
            {
                pm.Series.Remove(selectedItem.Data);
            }

            pm.InvalidatePlot(true);
        }
    }
}
