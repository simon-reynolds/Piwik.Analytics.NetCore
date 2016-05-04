using Newtonsoft.Json;

namespace Piwik.Analytics.NetCore.Results
{
    public class SiteIdResult
    {
        [JsonProperty("idsite")]
        public int SiteId { get; set; }
    }
}