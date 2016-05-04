#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

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
    ///     Service Gateway for Piwik VisitFrequency Module API
    ///     For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// <remarks>
    ///     This Analytics API is tested against Piwik 1.5
    /// </remarks>
    public class VisitFrequency : PiwikAnalytics
    {
        protected const string PLUGIN = "VisitFrequency";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public VisitFrequencyResult Get(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return SendRequest<VisitFrequencyResult>("get", parameters);
        }
    }
}