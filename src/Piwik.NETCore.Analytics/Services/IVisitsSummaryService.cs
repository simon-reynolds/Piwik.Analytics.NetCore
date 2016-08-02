using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IVisitsSummaryService :IService
    {
        Task<VisitSummary> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, string columns = null);
        Task<TotalVisits> GetVisitsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<UniqueVisitors> GetUniqueVisitorsAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }
}