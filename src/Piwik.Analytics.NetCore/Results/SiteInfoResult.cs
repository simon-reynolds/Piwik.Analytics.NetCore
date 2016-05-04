using Newtonsoft.Json;

namespace Piwik.Analytics.NetCore.Results
{
    public class SiteInfoResult
    {
        [JsonProperty("idsite")]
        public int SiteId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("main_url")]
        public string MainUrl { get; set; }
        
        [JsonProperty("ts_created")]
        public string Created { get; set; }
        
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        
        [JsonProperty("currency")]
        public string Currency { get; set; }
        
        [JsonProperty("excluded_ips")]
        public string ExcludedIps { get; set; }
        
        [JsonProperty("excluded_parameters")]
        public string ExcludedParameters { get; set; }
        
        [JsonProperty("feedburnerName")]
        public string FeedburnerName { get; set; }
        
        [JsonProperty("group")]
        public string Group { get; set; }
        
        [JsonProperty("ecommerce")]
        public string Ecommerce { get; set; }
    }
}