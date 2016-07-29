namespace Piwik.NETCore.Analytics.Tests
{
    public static class PiwikInitialization
    {
        public static PiwikAnalyticsClient Initialize()
        {
            var url = "http://demo.piwik.org/";
            var tokenAuth = "anonymous";
            
            return PiwikAnalyticsClient.CreateClient(url, tokenAuth);
        }
    }
}