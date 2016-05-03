#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

namespace Piwik.Analytics.NetCore
{
    public class ReferrerType
    {
        public static readonly ReferrerType DIRECT = new ReferrerType(1);
        public static readonly ReferrerType SEARCH_ENGINE = new ReferrerType(2);
        public static readonly ReferrerType WEBSITE = new ReferrerType(3);
        private readonly int _type;


        private ReferrerType(int type)
        {
            _type = type;
        }

        public int GetReferrerType()
        {
            return _type;
        }
    }
}