#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

namespace Piwik.NETCore.Analytics.Parameters
{
    internal class SimpleParameter : Parameter
    {
        private readonly string _value;

        public SimpleParameter(string name, string value) : base(name)
        {
            _value = value;
        }

        public SimpleParameter(string name, bool value)
            : base(name)
        {
            _value = value ? "1" : "0";
        }

        public SimpleParameter(string name, int value)
            : base(name)
        {
            _value = value.ToString();
        }

        public override string Serialize()
        {
            var parameter = string.Empty;

            if (!string.IsNullOrEmpty(_value))
            {
                parameter = "&" + Name + "=" + UrlEncode(_value);
            }

            return parameter;
        }
    }
}