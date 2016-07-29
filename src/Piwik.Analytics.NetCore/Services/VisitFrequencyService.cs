using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IVisitFrequencyService :IService
    {
       Task<VisitFrequencyResult> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }

    public class VisitFrequencyService : AbstractService<IVisitFrequencyService>, IVisitFrequencyService
    {
        protected override PiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "VisitFrequency";

        public VisitFrequencyService(PiwikAnalyticsClient client)
        {
            Client = client;
        }
        public async Task<VisitFrequencyResult> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new IdParameter(idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await ExecuteRequestAsync<VisitFrequencyResult>("get", parameters);
        }
    }
}