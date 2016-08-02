using Newtonsoft.Json;

namespace Piwik.NETCore.Analytics.Results
{
    public class ActionResult
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        
        /// <summary>
        /// Number of visits (30 minutes of inactivity is considered a new visit)
        /// </summary>
        /// <returns></returns>
        [JsonProperty("nb_visits")]
        public int Visits { get; set; }
        
        /// <summary>
        /// Number of views on this page
        /// </summary>
        [JsonProperty("nb_hits")]
        public int Hits { get; set; }
        
        /// <summary>
        /// Total time spent on this page, in seconds
        /// </summary>
        [JsonProperty("sum_time_spent")]
        public int SumTimeSpent { get; set; }
        
        [JsonPropertyAttribute("nb_hits_with_time_generation")]
        public int HitsWithTimeGeneration { get; set; }
        
        [JsonPropertyAttribute("min_time_generation")]
        public string MinTimeGeneration { get; set; }
        
        [JsonPropertyAttribute("max_time_generation")]
        public string MaxTimeGeneration { get; set; }
        
        [JsonPropertyAttribute("avg_time_generation")]
        public double AverageTimeGeneration { get; set; }
        
        /// <summary>
        /// Number of visits that started on this page
        /// </summary>
        [JsonProperty("exit_nb_visits")]
        public int EntryVisits { get; set; }
        
        /// <summary>
        /// Number of page views for visits that started on this page
        /// </summary>
        [JsonProperty("entry_nb_actions")]
        public int EntryActions { get; set; }
        
        /// <summary>
        /// Time spent, in seconds, by visits that started on this page
        /// </summary>
        [JsonProperty("entry_sum_visit_length")]
        public int EntrySumVisitLength { get; set; }
        
        /// <summary>
        /// Number of visits that started on this page, and bounced (viewed only one page)
        /// </summary>
        [JsonProperty("entry_bounce_count")]
        public int EntryBounceCount { get; set; }
        
        /// <summary>
        /// Number of visits that finished on this page
        /// </summary>
        [JsonProperty("exit_nb_visits")]
        public int ExitVisits { get; set; }
        
        /// <summary>
        /// Average time spent, in seconds, on this page
        /// </summary>
        [JsonProperty("avg_time_on_page")]
        public int AverageTimeOnPage { get; set; }
        
        /// <summary>
        /// Ratio of visitors leaving the website after landing on this page
        /// </summary>
        [JsonProperty("bounce_rate")]
        public string BounceRate { get; set; }
        
        /// <summary>
        /// Ratio of visitors that do not view any other page after this page
        /// </summary>
        [JsonProperty("exit_rate")]
        public string ExitRate { get; set; }
        
        /// <summary>
        /// Sum of daily unique visitors over days in the period. Piwik doesn't process unique visitors across the full period
        /// </summary>
        [JsonProperty("sum_daily_nb_uniq_visitors")]
        public int SumDailyUniqueVisitors { get; set; }
        
        /// <summary>
        /// Sum of daily unique visitors that started their visit on this page
        /// </summary>
        [JsonProperty("sum_daily_entry_nb_uniq_visitors")]
        public int SumDailyEntryUniqueVisitors { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("segment")]
        public string Segment { get; set; }
    }
}