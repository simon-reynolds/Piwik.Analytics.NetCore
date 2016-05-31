#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System.Text.Encodings.Web;

namespace Piwik.Analytics.NetCore.Parameters
{
    public abstract class Parameter
    {
        protected string Name;

        protected Parameter(string name)
        {
            Name = name;
        }

        public abstract string Serialize();

        protected static string UrlEncode(string value)
        {
            return UrlEncoder.Default.Encode(value);
        }
    }
}