using System.Text.Encodings.Web;

namespace Piwik.NETCore.Analytics.Parameters
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