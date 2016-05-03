#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

namespace Piwik.Analytics.NetCore.Parameters
{
    internal class ArrayParameter : Parameter
    {
        private readonly bool _inline;
        private readonly string[] _values;

        public ArrayParameter(string name, string[] values, bool inline = false) : base(name)
        {
            _values = values;
            _inline = inline;
        }

        public override string Serialize()
        {
            if (_values == null) return string.Empty;

            var parameter = string.Empty;
            if (_inline)
            {
                parameter = "&" + Name + "=";

                for (var i = 0; i < _values.Length; i++)
                {
                    parameter += UrlEncode(_values[i]) + ",";
                }
            }
            else
            {
                for (var i = 0; i < _values.Length; i++)
                {
                    parameter += "&" + Name + "[" + i + "]=" + UrlEncode(_values[i]);
                }
            }

            return parameter;
        }
    }
}