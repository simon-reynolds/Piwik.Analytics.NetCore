using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;
using Piwik.Analytics.NetCore.Results;

namespace Piwik.Analytics.NetCore.Modules
{
    public class VisitsSummary : PiwikAnalytics
    {
        private const string PLUGIN = "VisitsSummary";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public VisitSummary Get(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null,
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

            return SendRequest<VisitSummary>("get", parameters);
        }

        public TotalVisits GetVisits(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<TotalVisits>("getVisits", parameters);
        }

        public UniqueVisitors GetUniqueVisitors(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<UniqueVisitors>("getUniqueVisitors", parameters);
        }
    }
}