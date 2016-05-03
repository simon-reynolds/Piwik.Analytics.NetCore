#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using Newtonsoft.Json;
using System.Collections.Generic;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>

namespace Piwik.Analytics.NetCore.Modules
{
    public class ActionResult
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        
        [JsonProperty("nb_visits")]
        public int Visits { get; set; }
        
        [JsonProperty("nb_hits")]
        public int Hits { get; set; }
        
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
        
        [JsonProperty(Actions.ENTRY_NB_VISITS)]
        public int EntryVisits { get; set; }
        
        [JsonProperty(Actions.ENTRY_NB_ACTIONS)]
        public int EntryActions { get; set; }
        
        [JsonProperty(Actions.ENTRY_SUM_VISIT_LENGTH)]
        public int EntrySumVisitLength { get; set; }
        
        [JsonProperty(Actions.ENTRY_BOUNCE_COUNT)]
        public int EntryBounceCount { get; set; }
        
        [JsonProperty(Actions.EXIT_NB_VISITS)]
        public int ExitVisits { get; set; }
        
        [JsonProperty(Actions.AVG_TIME_ON_PAGE)]
        public int AverageTimeOnPage { get; set; }
        
        [JsonProperty(Actions.BOUNCE_RATE)]
        public string BounceRate { get; set; }
        
        [JsonProperty(Actions.EXIT_RATE)]
        public string ExitRate { get; set; }
        
        [JsonProperty("sum_daily_nb_uniq_visitors")]
        public int SumDailyUniqueVisitors { get; set; }
        
        [JsonProperty("sum_daily_entry_nb_uniq_visitors")]
        public int SumDailyEntryUniqueVisitors { get; set; }
        
        [JsonProperty("sum_daily_exit_nb_uniq_visitors")]
        public int SumDailyExitUniqueVisitors { get; set; }
        
        [JsonProperty(Actions.PAGE_URL)]
        public string Url { get; set; }
        
        [JsonProperty("segment")]
        public string Segment { get; set; }
    }
    
    /// <summary>
    ///     Service Gateway for Piwik Actions Module API
    ///     For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// <remarks>
    ///     This Analytics API is tested against Piwik 1.5
    /// </remarks>
    public class Actions : PiwikAnalytics
    {
        public const string LABEL = "label";
        public const string NB_VISITS = "nb_visits";
        public const string NB_UNIQ_VISITORS = "nb_uniq_visitors";
        public const string NB_HITS = "nb_hits";
        public const string SUM_TIME_SPENT = "sum_time_spent";
        public const string ENTRY_NB_UNIQ_VISITORS = "entry_nb_uniq_visitors";
        public const string ENTRY_NB_VISITS = "entry_nb_visits";
        public const string ENTRY_NB_ACTIONS = "entry_nb_actions";
        public const string ENTRY_SUM_VISIT_LENGTH = "entry_sum_visit_length";
        public const string ENTRY_BOUNCE_COUNT = "entry_bounce_count";
        public const string EXIT_NB_UNIQ_VISITORS = "exit_nb_uniq_visitors";
        public const string EXIT_NB_VISITS = "exit_nb_visits";
        public const string AVG_TIME_ON_PAGE = "avg_time_on_page";
        public const string BOUNCE_RATE = "bounce_rate";
        public const string EXIT_RATE = "exit_rate";
        public const string PAGE_URL = "url";

        private const string PLUGIN = "Actions";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public object GetPageUrls(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<List<ActionResult>>("getPageUrls", new List<Parameter>(parameters));

        }

        public object GetPageTitles(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<List<ActionResult>>("getPageTitles", new List<Parameter>(parameters));
        }
    }
}