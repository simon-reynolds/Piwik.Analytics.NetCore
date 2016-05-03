#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System;
using Piwik.Analytics.NetCore.Parameters;

namespace Piwik.Analytics.NetCore.Date
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