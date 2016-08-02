using System;
using Piwik.NETCore.Analytics.Parameters;

namespace Piwik.NETCore.Analytics.Date
{
    public class AbsoluteRangeDate : IPiwikDate
    {
        private readonly DateTimeOffset _dateEnd;
        private readonly DateTimeOffset _dateStart;

        public AbsoluteRangeDate(DateTimeOffset dateStart, DateTimeOffset dateEnd)
        {
            _dateStart = dateStart;
            _dateEnd = dateEnd;
        }

        public string Serialize()
        {
            return DateParameter.FormatDate(_dateStart) + "," + DateParameter.FormatDate(_dateEnd);
        }
    }
}