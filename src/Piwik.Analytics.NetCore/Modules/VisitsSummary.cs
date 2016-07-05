using System.Threading.Tasks;
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

        public async Task<VisitSummary> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null,
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

            return await SendRequestAsync<VisitSummary>("get", parameters);
        }

        public async Task<TotalVisits> GetVisitsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await SendRequestAsync<TotalVisits>("getVisits", parameters);
        }

        public async Task<UniqueVisitors> GetUniqueVisitorsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await SendRequestAsync<UniqueVisitors>("getUniqueVisitors", parameters);
        }
    }
}