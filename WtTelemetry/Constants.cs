namespace WtTelemetry
{
    public static class Constants
    {
        public const string IpAddress = "127.0.0.1";

        public const string UrlIndicators = "http://" + IpAddress + ":8111/indicators";
        public const string UrlState = "http://" + IpAddress + ":8111/state";
        //public const string UrlComments = "http://" + IpAddress + ":8111/indicators";
        //public const string UrlEvents = "http://" + IpAddress + ":8111/indicators";
        public const string UrlMapImg = "http://" + IpAddress + ":8111/map.img";
        public const string UrlMapObj = "http://" + IpAddress + ":8111/map_obj.json";
        public const string UrlMapInfo = "http://" + IpAddress + ":8111/map_info.json";

        public const int UpdateIntervalActive = 100;
        public const int UpdateIntervalIdle = 1000;

        public const double FtToM = 0.3048;
        public static readonly string[] ImperialPlanes = { "p-", "f-", "f2", "f3", "f4", "f6", "f7", "f8", "f9", "os",
            "sb", "tb", "a-", "pb", "am", "ad", "fj", "b-", "xp", "bt",
            "xa", "xf", "sp", "hu", "ty", "fi", "gl", "ni", "fu", "fu",
            "se", "bl", "be", "su", "te", "st", "mo", "we", "ha"
        };
    }
}