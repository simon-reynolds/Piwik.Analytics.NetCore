using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IActionsService :IService
    {
        Task<List<ActionResult>> GetPageUrlsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<List<ActionResult>> GetPageTitlesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }

    public class ActionsService : AbstractService<IActionsService>, IActionsService
    {
        protected override PiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "Actions";

        public ActionsService(PiwikAnalyticsClient client)
        {
            Client = client;
        }

        public async Task<List<ActionResult>> GetPageUrlsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new IdParameter(idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await ExecuteRequestAsync<List<ActionResult>>("getPageUrls", parameters);

        }

        public async Task<List<ActionResult>> GetPageTitlesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new IdParameter(idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await ExecuteRequestAsync<List<ActionResult>>("getPageTitles", parameters);
        }
    }
}