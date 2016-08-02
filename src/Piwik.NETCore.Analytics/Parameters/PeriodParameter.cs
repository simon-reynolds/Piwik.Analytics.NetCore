using Piwik.NETCore.Analytics.Date;

namespace Piwik.NETCore.Analytics.Parameters
{
    internal class PeriodParameter : Parameter
    {
        private readonly PiwikPeriod _period;

        public PeriodParameter(PiwikPeriod period) : base("period")
        {
            _period = period;
        }

        public override string Serialize()
        {
            var parameter = string.Empty;

            if (!string.IsNullOrWhiteSpace(_period.GetPeriod))
            {
                parameter = "&" + Name + "=" + UrlEncode(_period.GetPeriod);
            }

            return parameter;
        }
    }
}