namespace wthud3
{
    class ParamDescription
    {
        public ParamDescription(string key, string desc, string unit, string fmt)
        {
            Key = key;
            Description = desc;
            Unit = unit;
            Format = fmt;
        }

        public string Key { get; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Format { get; set; }
    }
}
