namespace Piwik.NETCore.Analytics.Tests
{
    public static class PiwikInitialization
    {
        public static PiwikAnalytics Initialize()
        {
            var url = "http://demo.piwik.org/";
            var tokenAuth = "anonymous";
            
            return PiwikAnalytics.CreateClient(url, tokenAuth);
        }
    }
}