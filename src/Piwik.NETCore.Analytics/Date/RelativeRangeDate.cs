namespace Piwik.NETCore.Analytics.Date
{
    public class RelativeRangeDate : IPiwikDate
    {
        private readonly int _nbDays;
        private readonly string _relativeRange;

        private RelativeRangeDate(string relativeRange, int nbDays)
        {
            _relativeRange = relativeRange;
            _nbDays = nbDays;
        }

        public string Serialize()
        {
            return _relativeRange + _nbDays;
        }

        public static RelativeRangeDate Last(int nbDays)
        {
            return new RelativeRangeDate("last", nbDays);
        }

        public static RelativeRangeDate Previous(int nbDays)
        {
            return new RelativeRangeDate("previous", nbDays);
        }
    }
}