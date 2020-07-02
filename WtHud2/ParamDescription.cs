using Newtonsoft.Json;
using System.ComponentModel;

namespace WtHud2
{
    class ParamDescription
    {
        [JsonConstructor]
        public ParamDescription(string name, string description, string unit, string format)
        {
            Name = name;
            Description = description;
            Unit = unit;
            Format = format;
        }

        public ParamDescription(string key)
        {
            Name = key;
            Description = key;
            Unit = "";
            Format = "7:F1";
        }

        public string Name { get; private set; }

        public string Description { get; set; }

        [DefaultValue("")]
        public string Unit { get; set; }

        [DefaultValue("7:F1")]
        public string Format { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is ParamDescription objAsParam)) return false;
            return Equals(objAsParam);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public bool Equals(ParamDescription other)
        {
            if (other == null) return false;
            return (this.Name.Equals(other.Name));
        }
    }
}
