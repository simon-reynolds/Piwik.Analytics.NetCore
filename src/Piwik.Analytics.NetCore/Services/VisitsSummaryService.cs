using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IVisitsSummaryService :IService
    {
        Task<VisitSummary> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string columns = null);
        Task<TotalVisits> GetVisitsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<UniqueVisitors> GetUniqueVisitorsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }

    public class VisitsSummaryService : AbstractService<IVisitsSummaryService>, IVisitsSummaryService
    {
        protected override PiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "VisitsSummary";

        public VisitsSummaryService(PiwikAnalyticsClient client)
        {
            Client = client;
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

            return await ExecuteRequestAsync<VisitSummary>("get", parameters);
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

            return await ExecuteRequestAsync<TotalVisits>("getVisits", parameters);
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

            return await ExecuteRequestAsync<UniqueVisitors>("getUniqueVisitors", parameters);
        }
    }
}