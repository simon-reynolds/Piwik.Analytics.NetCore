#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>

namespace Piwik.Analytics.NetCore.Modules
{
    /// <summary>
    ///     Service Gateway for Piwik UserSettings Module API
    ///     For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// <remarks>
    ///     This Analytics API is tested against Piwik 1.5
    /// </remarks>
    public class UserSettings : PiwikAnalytics
    {
        public const string LABEL = "label";
        public const string NB_UNIQ_VISITORS = "nb_uniq_visitors";
        public const string NB_VISITS = "nb_visits";
        public const string NB_ACTIONS = "nb_actions";
        public const string MAX_ACTIONS = "max_actions";
        public const string SUM_VISIT_LENGTH = "sum_visit_length";
        public const string BOUNCE_COUNT = "bounce_count";
        public const string NB_VISITS_CONVERTED = "nb_visits_converted";
        public const string LOGO = "logo";
        public const string SHORTLABEL = "shortLabel";
        public const string SUM_DAILY_NB_UNIQ_VISITORS = "sum_daily_nb_uniq_visitors";


        private const string PLUGIN = "UserSettings";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public object GetBrowser(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            if (PiwikPeriod.IsMultipleDates(period, date))
            {
                return SendRequest<Hashtable>("getBrowser", parameters);
            }
            return SendRequest<ArrayList>("getBrowser", parameters);
        }

        public object GetOs(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            if (PiwikPeriod.IsMultipleDates(period, date))
            {
                return SendRequest<Hashtable>("getOS", parameters);
            }
            return SendRequest<ArrayList>("getOS", parameters);
        }

        public object GetMobileOS(int idSite, PiwikPeriod period, IPiwikDate date)
        {
            var mobileOS = new []
            {
                "IPH", // iPhone
                "AND", // Android
                "IPD", // iPod
                "IPA", // iPad
                "BLB", // Blackberry
                "WP7", // Windows Phone 7
                "W65", // Windows Mobile 6.5
                "W61", // Windows Mobile 6.1
                "WOS", // Palm webOS
                "POS", // Palm OS
                "QNX", // QNX & RIM Tablet OS
                "SYM" // Symbian OS               
            };

            var segment = string.Empty;
            foreach (var OS in mobileOS)
            {
                segment += "operatingSystem==" + OS + ",";
            }

            return GetOs(idSite, period, date, segment);
        }
    }
}