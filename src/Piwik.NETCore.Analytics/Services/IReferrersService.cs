using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Results;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IReferrersService : IService
    {
        Task<List<ReferrerType>> GetReferrerType(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, ReferrerType referrerType = null);
        Task<List<ReferrerWesbite>> GetWebsitesAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, bool expanded = false);
    }
}