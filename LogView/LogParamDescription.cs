using OxyPlot;
using OxyPlot.Series;
using System.Collections.Generic;
using WtTelemetry;

namespace LogView
{
    class LogParamDescription
    {
        public LogParamDescription(string paramName, List<float> data)
        {
            Enabled = false;
            ParamName = paramName;
            Data = new LineSeries() { Title = paramName, ItemsSource = new List<DataPoint>() };

            NumEntries = 0;

            double t = 0;

            foreach (var item in data)
            {
                if (!float.IsNaN(item)) NumEntries++;

                var point = new DataPoint(t, item);
                (Data.ItemsSource as List<DataPoint>).Add(point);
                t += (double)Constants.UpdateIntervalActive / 1000;
            }
        }

        public bool Enabled { get; set; }

        public string ParamName { get; private set; }

        public int NumEntries { get; private set; }

        public LineSeries Data;
    }
}
