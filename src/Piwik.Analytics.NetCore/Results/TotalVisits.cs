using Newtonsoft.Json;

namespace Piwik.NETCore.Analytics.Results
{
    public class TotalVisits
    {
        [JsonProperty("value")]
        public int Visits { get; set; }
    }
    
    public class UniqueVisitors
    {
        [JsonProperty("value")]
        public int Visits { get; set; }
    }
}