using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;
using Piwik.NETCore.Analytics.Services;

namespace Piwik.NETCore.Analytics.ServicesImpl
{
    internal class ReferrersService : AbstractService<IReferrersService>, IReferrersService
    {
        internal override IPiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "Referers"; // API name is misspelt, this is not a typo

        internal ReferrersService(IPiwikAnalyticsClient client)
        {
            Client = client;
        }

        public async Task<List<ReferrerType>> GetReferrerType(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, ReferrerType referrerType = null)
        {
            Parameter[] parameters =
            {
                new IdParameter(idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment),
                new ReferrerTypeParameter(referrerType)
            };

            return await ExecuteRequestAsync<List<ReferrerType>>("getReferrerType", parameters);
        }

        public async Task<List<ReferrerWesbite>> GetWebsitesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, bool expanded = false)
        {
            Parameter[] parameters =
            {
                new IdParameter(idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment),
                new SimpleParameter("expanded", expanded)
            };

            return await ExecuteRequestAsync<List<ReferrerWesbite>>("getWebsites", parameters);
        }
    }
}