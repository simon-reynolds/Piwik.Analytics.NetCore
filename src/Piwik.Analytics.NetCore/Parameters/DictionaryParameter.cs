#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System.Collections.Generic;

namespace Piwik.NETCore.Analytics.Parameters
{
    internal class DictionaryParameter : Parameter
    {
        private readonly Dictionary<string, object> _values;

        public DictionaryParameter(string name, Dictionary<string, object> values)
            : base(name)
        {
            _values = values;
        }

        public override string Serialize()
        {
            if (_values == null) return string.Empty;


            var parameter = string.Empty;
            foreach (var kv in _values)
            {
                if (kv.Value == null)
                    continue;

                var value = kv.Value as string[];
                if (value != null)
                {
                    var arr = value;
                    foreach (var s in arr)
                    {
                        parameter += "&" + Name + "[" + kv.Key + "][]=" + UrlEncode(s);
                    }
                }
                else
                {
                    parameter += "&" + Name + "[" + kv.Key + "]=" + UrlEncode(kv.Value.ToString());
                }
            }
            return parameter;
        }
    }
}