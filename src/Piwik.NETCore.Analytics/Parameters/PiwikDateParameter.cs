using Piwik.NETCore.Analytics.Date;

namespace Piwik.NETCore.Analytics.Parameters
{
    internal class PiwikDateParameter : Parameter
    {
        private readonly IPiwikDate _piwikDate;

        public PiwikDateParameter(IPiwikDate date) : base("date")
        {
            _piwikDate = date;
        }

        public override string Serialize()
        {
            var parameter = string.Empty;

            if (_piwikDate != null)
            {
                parameter = "&" + Name + "=" + UrlEncode(_piwikDate.Serialize());
            }

            return parameter;
        }
    }
}