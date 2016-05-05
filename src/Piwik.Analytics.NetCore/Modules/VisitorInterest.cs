using System.Collections.Generic;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;
using Piwik.Analytics.NetCore.Results;

namespace Piwik.Analytics.NetCore.Modules
{
    public class VisitorInterest : PiwikAnalytics
    {
        private const string PLUGIN = "VisitorInterest";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public List<VisitsPerPage> GetNumberOfVisitsPerPage(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<List<VisitsPerPage>>("getNumberOfVisitsPerPage", parameters);
        }

        public List<VisitsPerVisitCount> GetNumberOfVisitsByVisitCount(int idSite, PiwikPeriod period, IPiwikDate date,
            string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<List<VisitsPerVisitCount>>("getNumberOfVisitsByVisitCount ", parameters);
        }
    }
}