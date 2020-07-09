using System.Collections.Generic;
using System.IO;

namespace WtLogging
{
    public static class LogWriter
    {
        private static FileStream fs;
        private static BinaryWriter writer;

        public static int NumEntries { get; private set; } = 0;

        public static long FileSize
        {
            get
            {
                return fs.Position;
            }
        }

        public static void StartNewLog(string filename)
        {
            fs = new FileStream(filename, FileMode.Create);
            writer = new BinaryWriter(fs);
            NumEntries = 0;
        }

        public static void WriteHeader(string craftName, ref List<string> IdToName)
        {
            writer.Write(LoggingProperties.LogProtocolVersion);
            writer.Write(craftName);
            writer.Write(IdToName.Count);
            foreach (var item in IdToName)
            {
                writer.Write(item);
            }
        }

        public static void AddRecord(ref Dictionary<byte, float> record)
        {
            writer.Write(record.Count);
            foreach (var item in record)
            {
                writer.Write(item.Key);
                writer.Write(item.Value);
            }
            _ = fs.FlushAsync();
            NumEntries++;
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
