using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Xunit;

namespace Piwik.NETCore.Analytics.Tests
{
    public class VisitSummaryTests
    {
        [Fact]
        public async Task GetSuccessfullyParsesRepsonse()
        {
            var client = PiwikInitialization.Initialize();

            var result = await client.VisitsSummaryService.GetAsync(7, PiwikPeriod.Month, MagicDate.Yesterday);

            Assert.True(result != null);
            Assert.True(result.Actions > 0);
        }

        [Fact]
        public async Task GetUniqueVisitorsSuccessfullyParsesRepsonse()
        {
            var client = PiwikInitialization.Initialize();

            var result = await client.VisitsSummaryService.GetUniqueVisitorsAsync(7, PiwikPeriod.Month, MagicDate.Yesterday);

            Assert.True(result != null);
            Assert.True(result.Visits > 0);
        }

        [Fact]
        public async Task GetVisitsSuccessfullyParsesRepsonse()
        {
            var client = PiwikInitialization.Initialize();

            var result = await client.VisitsSummaryService.GetVisitsAsync(7, PiwikPeriod.Month, MagicDate.Yesterday);

            Assert.True(result != null);
            Assert.True(result.Visits > 0);
        }
    }
}
