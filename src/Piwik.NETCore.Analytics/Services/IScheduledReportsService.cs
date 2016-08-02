using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Reports;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IScheduledReportsService : IService
    {
        Task<int> AddReportAsync(
            int idSite,
            string description,
            PiwikPeriod period,
            int hour,
            ReportType reportType,
            ReportFormat reportFormat,
            List<Statistic> includedStatistics,
            bool emailMe,
            string[] additionalEmails = null);

        Task<bool> UpdateReportAsync(
            int idReport,
            int idSite,
            string description,
            PiwikPeriod period,
            int hour,
            ReportType reportType,
            ReportFormat reportFormat,
            List<Statistic> includedStatistics,
            bool emailMe,
            string[] additionalEmails = null);

        Task<bool> DeleteReportAsync(int idReport);
    }
}