using Piwik.Analytics.NetCore;

namespace Piwik.Analytics.NetCore.Tests
{
    public static class PiwikInitialization
    {
        public static void Initialize()
        {
            var url = "http://demo.piwik.org/";
            var tokenAuth = "anonymous";
            
            PiwikAnalytics.Initialize(url, tokenAuth);
        }
    }
}