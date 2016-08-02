using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface ISitesManagerService : IService
    {
        /// <summary>
        ///     Add a piwik site
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="urls"></param>
        /// <param name="ecommerce"></param>
        /// <param name="excludedIps"></param>
        /// <param name="excludedQueryParameters"></param>
        /// <param name="timezone"></param>
        /// <param name="currency"></param>
        /// <param name="group"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        Task<int> AddSiteAsync(
            string siteName,
            string[] urls,
            bool ecommerce = false,
            string[] excludedIps = null,
            string[] excludedQueryParameters = null,
            string timezone = null,
            string currency = null,
            string group = null,
            DateTimeOffset startDate = default(DateTimeOffset));
        
        /// <summary>
        ///     Remove a Piwik site
        /// </summary>
        /// <param name="idSite"></param>
        /// <returns></returns>
        Task<bool> DeleteSiteAsync(int idSite);

        /// <summary>
        ///     Find sites from their URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<List<SiteIdResult>> GetSitesIdFromSiteUrlAsync(string url);

        /// <summary>
        ///     Find a site from its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<Uri>> GetSiteUrlsFromIdAsync(int siteId);

        Task<List<SiteInfoResult>> GetSiteFromIdAsync(int id);

        /// <summary>
        ///     Update a Piwik Site.
        ///     All the existing parameters need to be provided otherwise they will be erased from the database.
        /// </summary>
        /// <param name="idSite"></param>
        /// <param name="siteName"></param>
        /// <param name="urls"></param>
        /// <param name="ecommerce"></param>
        /// <param name="excludedIps"></param>
        /// <param name="excludedQueryParameters"></param>
        /// <param name="timezone"></param>
        /// <param name="currency"></param>
        /// <param name="group"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        Task<bool> UpdateSiteAsync(
            int idSite,
            string siteName,
            string[] urls,
            bool ecommerce = false,
            string[] excludedIps = null,
            string[] excludedQueryParameters = null,
            string timezone = null,
            string currency = null,
            string group = null,
            DateTimeOffset startDate = default(DateTimeOffset));
    }
}