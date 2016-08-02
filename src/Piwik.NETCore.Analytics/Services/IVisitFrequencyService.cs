using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IVisitFrequencyService :IService
    {
       Task<VisitFrequencyResult> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null);
    }
}