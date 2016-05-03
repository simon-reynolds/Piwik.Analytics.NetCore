using System.Collections;
using System.Collections.Generic;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;

namespace Piwik.Analytics.NetCore.Modules
{
    public class VisitsSummary : PiwikAnalytics
    {
        public const string NB_ACTIONS_PER_VISIT = "nb_actions_per_visit";
        public const string BOUNCE_RATE = "bounce_rate";
        public const string MAX_ACTIONS = "max_actions";
        public const string NB_ACTIONS = "nb_actions";
        public const string NB_VISITS = "nb_visits";
        public const string NB_VISITS_CONVERTED = "nb_visits_converted";
        public const string SUM_VISIT_LENGTH = "sum_visit_length";
        public const string BOUNCE_COUNT = "bounce_count";
        public const string AVG_TIME_ON_SITE = "avg_time_on_site";

        private const string PLUGIN = "VisitsSummary";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public Hashtable Get(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null,
            string columns = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment),
                new SimpleParameter("columns", columns)
            };

            return SendRequest<Hashtable>("get", new List<Parameter>(parameters));
        }

        public object GetVisits(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            if (PiwikPeriod.IsMultipleDates(period, date))
            {
                return SendRequest<Hashtable>("getVisits", new List<Parameter>(parameters));
            }

            return SendRequest<ArrayList>("getVisits", new List<Parameter>(parameters));
        }

        public object GetUniqueVisitors(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            if (PiwikPeriod.IsMultipleDates(period, date))
            {
                return SendRequest<Hashtable>("getUniqueVisitors", new List<Parameter>(parameters));
            }

            return SendRequest<ArrayList>("getUniqueVisitors", new List<Parameter>(parameters));
        }
    }
}