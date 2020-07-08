using System.Collections.Generic;
using System.IO;

namespace WtLogging
{
    public static class LogReader
    {
        public static List<string> IdToName = new List<string>();
        public static Dictionary<string, List<double>> LogTable = new Dictionary<string, List<double>>();

        public static string CraftName = "";

        public static void ReadLog(string filename)
        {
            IdToName.Clear();
            LogTable.Clear();
            CraftName = "";

            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                var logProtocolVersion = reader.ReadInt32();
                if (logProtocolVersion != LoggingProperties.LogProtocolVersion)
                    throw new InvalidDataException("This log data is not supported by this version of LogView!");

                CraftName = reader.ReadString();
                var headerLen = reader.ReadInt32();
                for (var i = 0; i < headerLen; ++i)
                {
                    var paramName = reader.ReadString();
                    IdToName.Add(paramName);
                    LogTable[paramName] = new List<double>();
                }

                while (fs.Position < fs.Length)
                {
                    var recordLen = reader.ReadInt32();
                    //var tempDict = new Dictionary<int, double>();

                    for (var i = 0; i < recordLen; ++i)
                    {
                        var paramId = reader.ReadInt32();
                        var paramVal = reader.ReadDouble();
                        var paramName = IdToName[paramId];

                        LogTable[paramName].Add(paramVal);
                        //tempDict.Add(paramId, paramVal);
                    }

                    //Log.Add(tempDict);
                }
            }
        }
    }
}
