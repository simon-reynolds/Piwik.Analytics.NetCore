using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;
using Piwik.NETCore.Analytics.Services;

namespace Piwik.NETCore.Analytics.ServicesImpl
{
    internal class SitesManagerService : AbstractService<ISitesManagerService>, ISitesManagerService
    {
        internal override IPiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "SitesManager";

        internal SitesManagerService(IPiwikAnalyticsClient client)
        {
            Client = client;
        }

        public async Task<int> AddSiteAsync(
            string siteName,
            string[] urls,
            bool ecommerce = false,
            string[] excludedIps = null,
            string[] excludedQueryParameters = null,
            string timezone = null,
            string currency = null,
            string group = null,
            DateTimeOffset startDate = default(DateTimeOffset))
        {
            Parameter[] parameters =
            {
                new SimpleParameter("siteName", siteName),
                new SimpleParameter("ecommerce", ecommerce),
                new ArrayParameter("excludedIps", excludedIps, true),
                new ArrayParameter("excludedQueryParameters", excludedQueryParameters, true),
                new ArrayParameter("urls", urls),
                new SimpleParameter("timezone", timezone),
                new SimpleParameter("currency", currency),
                new SimpleParameter("group", group),
                new DateParameter("startDate", startDate)
            };

            return await ExecuteRequestAsync<int>("addSite", parameters);
        }

        public async Task<bool> DeleteSiteAsync(int idSite)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite)
            };

            return await ExecuteRequestAsync<bool>("deleteSite", parameters);
        }

        public async Task<List<SiteIdResult>> GetSitesIdFromSiteUrlAsync(string url)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("url", url)
            };

            return await ExecuteRequestAsync<List<SiteIdResult>>("getSitesIdFromSiteUrl", parameters);
        }

        public async Task<List<Uri>> GetSiteUrlsFromIdAsync(int siteId)
        {
            var parameter = new SimpleParameter("idSite", siteId);

            return await ExecuteRequestAsync<List<Uri>>("getSiteUrlsFromId", parameter);
        }

        public async Task<List<SiteInfoResult>> GetSiteFromIdAsync(int id)
        {
            var parameter = new SimpleParameter("idSite", id);

            return await ExecuteRequestAsync<List<SiteInfoResult>>("getSiteFromId", parameter);
        }

        public async Task<bool> UpdateSiteAsync(
            int idSite,
            string siteName,
            string[] urls,
            bool ecommerce = false,
            string[] excludedIps = null,
            string[] excludedQueryParameters = null,
            string timezone = null,
            string currency = null,
            string group = null,
            DateTimeOffset startDate = default(DateTimeOffset))
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new SimpleParameter("siteName", siteName),
                new SimpleParameter("ecommerce", ecommerce),
                new ArrayParameter("excludedIps", excludedIps, true),
                new ArrayParameter("excludedQueryParameters", excludedQueryParameters, true),
                new ArrayParameter("urls", urls),
                new SimpleParameter("timezone", timezone),
                new SimpleParameter("currency", currency),
                new SimpleParameter("group", group),
                new DateParameter("startDate", startDate)
            };

            return await ExecuteRequestAsync<bool>("updateSite", parameters);
        }
    }
}