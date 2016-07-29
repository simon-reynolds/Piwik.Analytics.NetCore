using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IVisitorInterestService :IService
    {
        Task<List<VisitsPerPage>> GetNumberOfVisitsPerPageAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<List<VisitsPerVisitCount>> GetNumberOfVisitsByVisitCountAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }

    public class VisitorInterestService : AbstractService<IVisitorInterestService>, IVisitorInterestService
    {
        protected override PiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "VisitorInterest";

        public VisitorInterestService(PiwikAnalyticsClient client)
        {
            Client = client;
        }
        public async Task<List<VisitsPerPage>> GetNumberOfVisitsPerPageAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await ExecuteRequestAsync<List<VisitsPerPage>>("getNumberOfVisitsPerPage", parameters);
        }

        public async Task<List<VisitsPerVisitCount>> GetNumberOfVisitsByVisitCountAsync(int idSite, PiwikPeriod period, IPiwikDate date,
            string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await ExecuteRequestAsync<List<VisitsPerVisitCount>>("getNumberOfVisitsByVisitCount ", parameters);
        }
    }
}