using System;
using Piwik.NETCore.Analytics.Parameters;

namespace Piwik.NETCore.Analytics.Date
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