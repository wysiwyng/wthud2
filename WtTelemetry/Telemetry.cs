using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WtTelemetry
{
    public static class Telemetry
    {
        private static HttpClient Client;

        static Telemetry()
        {
            Client = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(100)
            };
        }

        public static async Task<Dictionary<string, string>> GetJson(string url)
        {
            try
            {
                HttpResponseMessage resp = await Client.GetAsync(url);
                resp.EnsureSuccessStatusCode();
                var j = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(j);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string FindAltitude(ref Dictionary<string, string> obj)
        {
            var name = obj["type"];

            if (Constants.ImperialPlanes.Contains(name.Substring(0, 2)))
            {
                if (obj.ContainsKey("altitude_10k"))
                    return (double.Parse(obj["altitude_10k"]) * Constants.FtToM).ToString();
                if (obj.ContainsKey("altitude_hour"))
                    return (double.Parse(obj["altitude_hour"]) * Constants.FtToM).ToString();
                if (obj.ContainsKey("altitude_min"))
                    return (double.Parse(obj["altitude_min"]) * Constants.FtToM).ToString();
            }
            else
            {
                if (obj.ContainsKey("altitude_10k"))
                    return obj["altitude_10k"];
                if (obj.ContainsKey("altitude_hour"))
                    return obj["altitude_hour"];
                if (obj.ContainsKey("altitude_min"))
                    return obj["altitude_min"];
            }

            return "0.0";
        }

        public static async Task<Dictionary<string, string>> GetIndicators()
        {
            var obj = await GetJson(Constants.UrlIndicators);
            if (obj == null) return null;

            var valid = bool.Parse(obj["valid"]);
            if (valid)
            {
                if (obj.ContainsKey("aviahorizon_pitch"))
                    obj["aviahorizon_pitch"] = (-double.Parse(obj["aviahorizon_pitch"], CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
                if (obj.ContainsKey("aviahorizon_roll"))
                    obj["aviahorizon_roll"] = (-double.Parse(obj["aviahorizon_roll"], CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);

                obj["alt_m"] = FindAltitude(ref obj);
                return obj;
            }

            return null;
        }

        public static async Task<Dictionary<string, string>> GetState()
        {
            var obj = await GetJson(Constants.UrlState);
            if (obj == null) return null;

            var valid = bool.Parse(obj["valid"]);

            if (valid) return obj;

            return null;
        }

        public static async Task<Dictionary<string, string>> GetFlightData()
        {
            var ind_task = GetIndicators();
            var state_task = GetState();

            await Task.WhenAll(ind_task, state_task);

            var ind = ind_task.Result;
            var state = state_task.Result;

            if (ind == null || state == null) return null;

            if (bool.Parse(ind["valid"]) && bool.Parse(ind["valid"]))
            {
                var obj = ind.Concat(state).GroupBy(e => e.Key).ToDictionary(g => g.Key, g => g.First().Value);
                return obj;
            }

            return null;
        }
    }
}
