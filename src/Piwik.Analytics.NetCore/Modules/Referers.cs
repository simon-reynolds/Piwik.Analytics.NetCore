#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System.Collections;
using System.Collections.Generic;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>

namespace Piwik.Analytics.NetCore.Modules
{
    /// <summary>
    ///     Service Gateway for Piwik Referers Module API
    ///     For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// <remarks>
    ///     This Analytics API is tested against Piwik 1.5
    /// </remarks>
    public class Referers : PiwikAnalytics
    {
        public const string LABEL = "label";
        public const string NB_UNIQ_VISITORS = "nb_uniq_visitors";
        public const string NB_VISITS = "nb_visits";
        public const string NB_ACTIONS = "nb_actions";
        public const string MAX_ACTIONS = "max_actions";
        public const string SUM_VISIT_LENGTH = "sum_visit_length";
        public const string BOUNCE_COUNT = "bounce_count";
        public const string NB_VISITS_CONVERTED = "nb_visits_converted";
        public const string IDSUBDATATABLE = "idsubdatatable";
        public const string NB_CONVERSIONS = "nb_conversions";
        public const string REVENUE = "revenue";
        public const string SUBTABLE = "subtable";

        private const string PLUGIN = "Referers";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public object GetWebsites(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null,
            bool expanded = false)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment),
                new SimpleParameter("expanded", expanded)
            };

            if (PiwikPeriod.IsMultipleDates(period, date))
            {
                var hash = SendRequest<Hashtable>("getWebsites", new List<Parameter>(parameters));
                return new List<Hashtable> {hash};
            }
            return SendRequest<ArrayList>("getWebsites", new List<Parameter>(parameters));
        }

        public object GetRefererType(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null,
            RefererType refererType = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment),
                new RefererTypeParameter("typeReferer", refererType)
            };

            if (PiwikPeriod.IsMultipleDates(period, date))
            {
                return SendRequest<Hashtable>("getRefererType", new List<Parameter>(parameters));
            }
            return SendRequest<ArrayList>("getRefererType", new List<Parameter>(parameters));
        }
    }
}