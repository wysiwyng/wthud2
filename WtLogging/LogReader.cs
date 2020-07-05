using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WtLogging
{
    public class LogReader
    {
        public static List<string> IdToName = new List<string>();
        public static List<Dictionary<int, double>> Log = new List<Dictionary<int, double>>();

        public static void ReadLog(string filename)
        {
            IdToName.Clear();
            Log.Clear();

            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                var headerLen = reader.ReadInt32();
                for (var i = 0; i < headerLen; ++i)
                {
                    IdToName.Add(reader.ReadString());
                }

                while(fs.Position < fs.Length)
                {
                    var recordLen = reader.ReadInt32();
                    var tempDict = new Dictionary<int, double>();

                    for (var i = 0; i < recordLen; ++i)
                    {
                        tempDict.Add(reader.ReadInt32(), reader.ReadDouble());
                    }

                    Log.Add(tempDict);
                }
            }
        }
    }
}
