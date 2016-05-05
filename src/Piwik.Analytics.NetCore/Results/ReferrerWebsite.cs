using Newtonsoft.Json;

namespace Piwik.Analytics.NetCore.Results
{
    public class ReferrerWesbite
    {
        [JsonProperty("label")]
        public string Referrer { get; set; }
        
        /// <summary>
        /// Number of visits (30 minutes of inactivity is considered a new visit)
        /// </summary>
        /// <returns></returns>
        [JsonProperty("nb_visits")]
        public int Visits { get; set; }
        
        /// <summary>
        /// Number of unique visitors
        /// </summary>
        /// <returns></returns>
        [JsonProperty("nb_uniq_visitors")]
        public int UniqueVisitors { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nb_actions")]
        public int Actions { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nb_users")]
        public int Users { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("max_actions")]
        public int MaxActions { get; set; }
        
        /// <summary>
        /// Total time spent on this page, in seconds
        /// </summary>
        [JsonProperty("sum_visit_length")]
        public int SumVisitLength { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bounce_count")]
        public int BounceCount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nb_visits_converted")]
        public int VisitsConverted { get; set; }        
        
        [JsonProperty("segment")]
        public string Segment { get; set; }
    }
}