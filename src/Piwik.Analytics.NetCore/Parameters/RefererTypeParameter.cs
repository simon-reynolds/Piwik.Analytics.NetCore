#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

namespace Piwik.Analytics.NetCore.Parameters
{
    public class RefererTypeParameter : Parameter
    {
        private readonly RefererType _refererType;

        public RefererTypeParameter(string name, RefererType refererType)
            : base(name)
        {
            _refererType = refererType;
        }

        public override string Serialize()
        {
            var parameter = string.Empty;

            if (_refererType != null)
            {
                parameter = "&" + Name + "=" + UrlEncode(_refererType.getType().ToString());
            }

            return parameter;
        }
    }
}