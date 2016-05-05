using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Modules;
using Xunit;

namespace Piwik.Analytics.NetCore.Tests
{
    public class VisitSummaryTests
    {
        [Fact]
        public void GetSuccessfullyParsesRepsonse()
        {
            PiwikInitialization.Initialize();
            
            var visitSummary = new VisitsSummary();
            var result = visitSummary.Get(7, PiwikPeriod.Month, MagicDate.Yesterday);
            
            Assert.True(result != null);            
            Assert.True(result.Actions > 0);
        }
        
        [Fact]
        public void GetUniqueVisitorsSuccessfullyParsesRepsonse()
        {
            PiwikInitialization.Initialize();
            
            var visitSummary = new VisitsSummary();
            var result = visitSummary.GetUniqueVisitors(7, PiwikPeriod.Month, MagicDate.Yesterday);
            
            Assert.True(result != null);            
            Assert.True(result.Visits > 0);
        }
        
        [Fact]
        public void GetVisitsSuccessfullyParsesRepsonse()
        {
            PiwikInitialization.Initialize();
            
            var visitSummary = new VisitsSummary();
            var result = visitSummary.GetVisits(7, PiwikPeriod.Month, MagicDate.Yesterday);
            
            Assert.True(result != null);            
            Assert.True(result.Visits > 0);
        }
    }
}
