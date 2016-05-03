#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System;
using Piwik.Analytics.NetCore.Parameters;

namespace Piwik.Analytics.NetCore.Date
{
    public class SimpleDate : IPiwikDate
    {
        private readonly DateTimeOffset _date;

        public SimpleDate(DateTimeOffset date)
        {
            _date = date;
        }

        public string Serialize()
        {
            return DateParameter.FormatDate(_date);
        }
    }
}