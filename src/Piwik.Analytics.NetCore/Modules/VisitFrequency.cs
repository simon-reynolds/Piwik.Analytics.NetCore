#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System.Collections.Generic;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;
using Newtonsoft.Json;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>

namespace Piwik.Analytics.NetCore.Modules
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
    
    /// <summary>
    ///     Service Gateway for Piwik VisitFrequency Module API
    ///     For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// <remarks>
    ///     This Analytics API is tested against Piwik 1.5
    /// </remarks>
    public class VisitFrequency : PiwikAnalytics
    {
        public const string NB_UNIQ_VISITORS_RETURNING = "nb_uniq_visitors_returning";
        public const string NB_VISITS_RETURNING = "nb_visits_returning";
        public const string NB_ACTIONS_RETURNING = "nb_actions_returning";
        public const string MAX_ACTIONS_RETURNING = "max_actions_returning";
        public const string SUM_VISIT_LENGTH_RETURNING = "sum_visit_length_returning";
        public const string BOUNCE_COUNT_RETURNING = "bounce_count_returning";
        public const string NB_VISITS_CONVERTED_RETURNING = "nb_visits_converted_returning";
        public const string BOUNCE_RATE_RETURNING = "bounce_rate_returning";
        public const string NB_ACTIONS_PER_VISIT_RETURNING = "nb_actions_per_visit_returning";
        public const string AVG_TIME_ON_SITE_RETURNING = "avg_time_on_site_returning";

        private const string PLUGIN = "VisitFrequency";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public VisitFrequencyResult Get(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<VisitFrequencyResult>("get", new List<Parameter>(parameters));
        }
    }
}