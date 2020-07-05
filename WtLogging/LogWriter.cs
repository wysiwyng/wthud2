using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace WtLogging
{
    public class LogWriter
    {
        private static FileStream fs;
        private static BinaryWriter writer;

        public static void StartNewLog(string filename)
        {
            fs = new FileStream(filename, FileMode.Create);
            writer = new BinaryWriter(fs);
        }

        public static void WriteHeader(ref List<string> IdToName)
        {
            writer.Write(IdToName.Count);
            foreach (var item in IdToName)
            {
                writer.Write(item);
            }
        }

        public static void AddRecord(ref Dictionary<int, double> record)
        {
            writer.Write(record.Count);
            foreach (var item in record)
            {
                writer.Write(item.Key);
                writer.Write(item.Value);
            }
            _ = fs.FlushAsync();
        }

        public static void FinalizeLog()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }

            if (fs != null)
            {
                fs.Dispose();
                fs = null;
            }
        }
    }
}
