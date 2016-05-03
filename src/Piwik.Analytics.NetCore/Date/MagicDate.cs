#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

namespace Piwik.Analytics.NetCore.Date
{
    public class MagicDate : IPiwikDate
    {
        public static readonly MagicDate Today = new MagicDate("today");
        public static readonly MagicDate Yesterday = new MagicDate("yesterday");
        private readonly string _keyword;

        private MagicDate(string keyword)
        {
            _keyword = keyword;
        }

        public string Serialize()
        {
            return _keyword;
        }
    }
}