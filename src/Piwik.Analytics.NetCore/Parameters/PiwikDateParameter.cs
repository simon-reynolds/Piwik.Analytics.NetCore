#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using Piwik.Analytics.NetCore.Date;

namespace Piwik.Analytics.NetCore.Parameters
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