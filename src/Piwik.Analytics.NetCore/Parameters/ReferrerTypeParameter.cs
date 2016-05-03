#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

namespace Piwik.Analytics.NetCore.Parameters
{
    public class ReferrerTypeParameter : Parameter
    {
        private readonly ReferrerType _referrerType;

        public ReferrerTypeParameter(ReferrerType refererType)
            : base("typeReferrer")
        {
            _referrerType = refererType;
        }

        public override string Serialize()
        {
            var parameter = string.Empty;

            if (_referrerType != null)
            {
                parameter = "&" + Name + "=" + UrlEncode(_referrerType.GetReferrerType().ToString());
            }

            return parameter;
        }
    }
}