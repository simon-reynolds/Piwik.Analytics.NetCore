using Newtonsoft.Json;

namespace Piwik.Analytics.NetCore.Results
{
    public class VisitFrequencyResult
    {
        [JsonProperty("nb_uniq_visitors_returning")]
        public int UniqueVisitorsReturning { get; set; }
        
        [JsonProperty("nb_users_returning")]
        public int UsersReturning { get; set; }
        
        [JsonProperty("nb_visits_returning")]
        public int VisitsReturning { get; set; }
        
        [JsonProperty("nb_actions_returning")]
        public int ActionsReturning { get; set; }
        
        [JsonProperty("nb_visits_converted_returning")]
        public int VisitsConvertedReturning { get; set; }
        
        [JsonProperty("bounce_count_returning")]
        public int BounceCountReturning { get; set; }
        
        [JsonProperty("sum_visit_length_returning")]
        public int SumVisitLengthReturning { get; set; }
        
        [JsonProperty("max_actions_returning")]
        public int MaxActionsReturning { get; set; }
        
        [JsonProperty("bounce_rate_returning")]
        public string BounceRateReturning { get; set; }
        
        [JsonProperty("nb_actions_per_visit_returning")]
        public double ActionsPerVisitReturning { get; set; }
        
        [JsonProperty("avg_time_on_site_returning")]
        public int AverageTimeOnSiteReturning { get; set; }
    }
}