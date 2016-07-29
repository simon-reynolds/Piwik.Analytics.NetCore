using Newtonsoft.Json;

namespace Piwik.NETCore.Analytics.Results
{
    public class SiteIdResult
    {
        [JsonProperty("idsite")]
        public int SiteId { get; set; }
    }
}