using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;
using Piwik.NETCore.Analytics.Services;

namespace Piwik.NETCore.Analytics.ServicesImpl
{
    internal class VisitFrequencyService : AbstractService<IVisitFrequencyService>, IVisitFrequencyService
    {
        internal override IPiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "VisitFrequency";

        internal VisitFrequencyService(IPiwikAnalyticsClient client)
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