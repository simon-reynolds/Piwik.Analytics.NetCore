#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System.Collections.Generic;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;
using Piwik.Analytics.NetCore.Results;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>

namespace Piwik.Analytics.NetCore.Modules
{
    /// <summary>
    ///     Service Gateway for Piwik Referers Module API
    ///     For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// <remarks>
    ///     This Analytics API is tested against Piwik 1.5
    /// </remarks>
    public class Referrers : PiwikAnalytics
    {
        private const string PLUGIN = "Referers"; // API name is misspelt, this is not a typo

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public object GetWebsites(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null,
            bool expanded = false)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment),
                new SimpleParameter("expanded", expanded)
            };

            return SendRequest<List<ReferrerWesbite>>("getWebsites", parameters);
        }

        public object GetReferrerType(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null,
            ReferrerType referrerType = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment),
                new ReferrerTypeParameter(referrerType)
            };

            return SendRequest<List<ReferrerType>>("getReferrerType", parameters);
        }
    }
}