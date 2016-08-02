using Newtonsoft.Json;

namespace Piwik.NETCore.Analytics.Results
{
    public class VisitSummary
    {
        [JsonProperty("nb_uniq_visitors")]
        public int UniqueVisitors { get; set; }
        
        [JsonProperty("nb_users")]
        public int Users { get; set; }
        
        [JsonProperty("nb_visits")]
        public int Visits { get; set; }
        
        [JsonProperty("nb_actions")]
        public int Actions { get; set; }
        
        [JsonProperty("nb_visits_converted")]
        public int VisitsConverted { get; set; }
        
        [JsonProperty("bounce_count")]
        public int BounceCount { get; set; }
        
        [JsonProperty("sum_visit_length")]
        public int SumVisitLength { get; set; }
        
        [JsonProperty("max_actions")]
        public int MaxActions { get; set; }
        
        [JsonProperty("bounce_rate")]
        public string BounceRate { get; set; }
        
        [JsonProperty("nb_actions_per_visit")]
        public double ActionsPerVisit { get; set; }
        
        [JsonProperty("avg_time_on_site")]
        public int AverageTimeOnSite { get; set; }
    }
}