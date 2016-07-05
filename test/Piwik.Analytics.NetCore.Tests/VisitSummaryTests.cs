using System.Threading.Tasks;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Modules;
using Xunit;

namespace Piwik.Analytics.NetCore.Tests
{
    public class VisitSummaryTests
    {
        [Fact]
        public async Task GetSuccessfullyParsesRepsonse()
        {
            PiwikInitialization.Initialize();

            var visitSummary = new VisitsSummary();
            var result = await visitSummary.GetAsync(7, PiwikPeriod.Month, MagicDate.Yesterday);

            Assert.True(result != null);
            Assert.True(result.Actions > 0);
        }

        [Fact]
        public async Task GetUniqueVisitorsSuccessfullyParsesRepsonse()
        {
            PiwikInitialization.Initialize();

            var visitSummary = new VisitsSummary();
            var result = await visitSummary.GetUniqueVisitorsAsync(7, PiwikPeriod.Month, MagicDate.Yesterday);

            Assert.True(result != null);
            Assert.True(result.Visits > 0);
        }

        [Fact]
        public async Task GetVisitsSuccessfullyParsesRepsonse()
        {
            PiwikInitialization.Initialize();

            var visitSummary = new VisitsSummary();
            var result = await visitSummary.GetVisitsAsync(7, PiwikPeriod.Month, MagicDate.Yesterday);

            Assert.True(result != null);
            Assert.True(result.Visits > 0);
        }
    }
}
