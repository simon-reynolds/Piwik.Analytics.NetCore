using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IVisitorInterestService :IService
    {
        Task<List<VisitsPerPage>> GetNumberOfVisitsPerPageAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
        Task<List<VisitsPerVisitCount>> GetNumberOfVisitsByVisitCountAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }
}