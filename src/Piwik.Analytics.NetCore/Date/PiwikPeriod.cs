#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

namespace Piwik.NETCore.Analytics.Date
{
    public struct PiwikPeriod
    {
        public static readonly PiwikPeriod Day = new PiwikPeriod("day");
        public static readonly PiwikPeriod Week = new PiwikPeriod("week");
        public static readonly PiwikPeriod Month = new PiwikPeriod("month");
        public static readonly PiwikPeriod Year = new PiwikPeriod("year");
        public static readonly PiwikPeriod Range = new PiwikPeriod("range");
        private readonly string _period;

        private PiwikPeriod(string period)
        {
            _period = period;
        }

        public string GetPeriod
        {
            get { return _period; }
        }

        public static bool IsMultipleDates(PiwikPeriod period, IPiwikDate date)
        {
            return
                !string.Equals(Range.GetPeriod, period.GetPeriod) &&
                (date is AbsoluteRangeDate || date is RelativeRangeDate);
        }
    }
}