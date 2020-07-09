using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WtLogging;

namespace LogView
{
    public partial class LogView : Form
    {
        private BindingSource logDataBs = new BindingSource();

        private PlotModel pm = new PlotModel();
        private string loadedLogPath;

        public LogView()
        {
            InitializeComponent();
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            logDataBs.DataSource = typeof(LogParamDescription);

            PlotConfigDGV.DataSource = logDataBs;
            PlotConfigDGV.AutoGenerateColumns = true;

            PlotConfigDGV.Columns[0].Width = 30;
            PlotConfigDGV.Columns[2].Width = 80;

            logDataBs.ListChanged += LogDataBs_ListChanged;

            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time, s", MajorGridlineStyle = LineStyle.Solid });
            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Value", MajorGridlineStyle = LineStyle.Solid });

            TelemPlotView.Model = pm;
        }

        private void LoadLogBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            var res = dlg.ShowDialog();

            if (res != DialogResult.OK) return;

            LogReader.ReadLog(dlg.FileName);
            loadedLogPath = dlg.FileName;

            logDataBs.Clear();
            foreach (var item in LogReader.IdToName)
            {
                logDataBs.Add(new LogParamDescription(item, LogReader.LogTable[item]));
            }

            pm.Series.Clear();
            pm.Title = LogReader.CraftName;
            pm.InvalidatePlot(true);
            ExportCSVBtn.Enabled = true;
        }

        private void LogDataBs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType != System.ComponentModel.ListChangedType.ItemChanged) return;

            var changedIdx = e.NewIndex;
            var selectedItem = (LogParamDescription)logDataBs[changedIdx];

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

        private void PlotConfigDGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                PlotConfigDGV.EndEdit();
            }
        }

        private void ExportCSVBtn_Click(object sender, EventArgs e)
        {
            var cult = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cult.NumberFormat.NaNSymbol = "";

            var dlg = new SaveFileDialog()
            {
                FileName = Path.Combine(Path.GetDirectoryName(loadedLogPath), Path.GetFileNameWithoutExtension(loadedLogPath) + ".csv"),
                DefaultExt = ".csv",
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            using (var writer = new StreamWriter(dlg.FileName))
            {
                writer.WriteLine(string.Join(";", LogReader.IdToName));

                for (var i = 0; i < LogReader.LogEntries; ++i)
                {
                    var t = from a in LogReader.LogTable select a.Value[i].ToString(cult);
                    writer.WriteLine(string.Join(";", t));
                }
            }
        }
    }
}
