using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IActionsService :IService
    {   
        Task<object> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string columns = null);
        Task<List<ActionResult>> GetPageUrlsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<object> GetPageUrlsFollowingSiteSearchAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null);
        Task<object> GetPageTitlesFollowingSiteSearchAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null);
        Task<object> GetEntryPageUrlsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null);
        Task<object> GetExitPageUrlsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null);
        Task<object> GetPageUrlAsync(string pageUrl, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<List<ActionResult>> GetPageTitlesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<object> GetEntryPageTitlesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null);
        Task<object> GetExitPageTitlesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null);
        Task<object> GetPageTitleAsync(string pageName, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<object> GetDownloadsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null, string flat = null);
        Task<object> GetDownloadAsync(string downloadUrl, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<object> GetOutlinksAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null, string flat = null);
        Task<object> GetOutlinkAsync(string outlinkUrl, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<object> GetSiteSearchKeywordsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<object> GetSiteSearchNoResultKeywordsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<object> GetSiteSearchCategoriesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }

    public class ActionsService : AbstractService<IActionsService>, IActionsService
    {
        protected override PiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "Actions";

        public ActionsService(PiwikAnalyticsClient client)
        {
            Client = client;
        }

        public Task<object> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string columns = null)
        {
            throw new NotImplementedException();
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

        public Task<object> GetPageUrlsFollowingSiteSearchAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetPageTitlesFollowingSiteSearchAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetEntryPageUrlsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetExitPageUrlsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetPageUrlAsync(string pageUrl, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            throw new NotImplementedException();
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

        public Task<object> GetEntryPageTitlesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetExitPageTitlesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetPageTitleAsync(string pageName, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetDownloadsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null, string flat = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetDownloadAsync(string downloadUrl, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetOutlinksAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string expanded = null, string idSubtable = null, string flat = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetOutlinkAsync(string outlinkUrl, int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSiteSearchKeywordsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSiteSearchNoResultKeywordsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSiteSearchCategoriesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            throw new NotImplementedException();
        }
    }
}