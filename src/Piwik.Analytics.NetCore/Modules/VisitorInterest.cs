using System.Collections;
using System.Collections.Generic;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;

namespace Piwik.Analytics.NetCore.Modules
{
    public class VisitorInterest : PiwikAnalytics
    {
        public const string LABEL = "label";
        public const string NB_VISITS = "nb_visits";
        public const string NB_VISITS_PERCENTAGE = "nb_visits_percentage";

        private const string PLUGIN = "VisitorInterest";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public object GetNumberOfVisitsPerPage(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
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
                return SendRequest<Hashtable>("getNumberOfVisitsPerPage", new List<Parameter>(parameters));
            }
            return SendRequest<ArrayList>("getNumberOfVisitsPerPage", new List<Parameter>(parameters));
        }

        public object GetNumberOfVisitsByVisitCount(int idSite, PiwikPeriod period, IPiwikDate date,
            string segment = null)
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
                return SendRequest<Hashtable>("getNumberOfVisitsByVisitCount ", new List<Parameter>(parameters));
            }
            return SendRequest<ArrayList>("getNumberOfVisitsByVisitCount ", new List<Parameter>(parameters));
        }
    }
}