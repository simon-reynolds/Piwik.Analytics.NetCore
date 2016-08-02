using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Reports;
using Piwik.NETCore.Analytics.Services;

namespace Piwik.NETCore.Analytics.ServicesImpl
{
    /// <summary>
    ///     Service Gateway for Piwik ScheduledReports Module API
    ///     For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// <remarks>
    ///     This Analytics API is tested against Piwik 2.13.1
    ///     Implementation missing for ScheduledReports.getReports, ScheduledReports.generateReport and
    ///     ScheduledReports.sendReport
    /// </remarks>
    internal class ScheduledReportsService : AbstractService<IScheduledReportsService>, IScheduledReportsService
    {
        internal override IPiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "ScheduledReports";

        internal ScheduledReportsService(IPiwikAnalyticsClient client)
        {
            Client = client;
        }

        /// <summary>
        ///     Add a new scheduled report
        /// </summary>
        /// <param name="idSite">ID of the piwik site</param>
        /// <param name="description">Description of the report</param>
        /// <param name="period">A piwik period</param>
        /// <param name="hour">Defines the hour at which the report will be sent</param>
        /// <param name="reportType">The report type</param>
        /// <param name="reportFormat">The report format</param>
        /// <param name="includedStatistics">The included statistics</param>
        /// <param name="emailMe">true if the report should be sent to the own user</param>
        /// <param name="additionalEmails">A string array of additional email recipients</param>
        /// <returns>The ID of the added report</returns>
        public async Task<int> AddReportAsync(
            int idSite,
            string description,
            PiwikPeriod period,
            int hour,
            ReportType reportType,
            ReportFormat reportFormat,
            List<Statistic> includedStatistics,
            bool emailMe,
            string[] additionalEmails = null
            )
        {
            var additionalParameters = new Dictionary<string, object>
            {
                {"emailMe", emailMe.ToString().ToLower()},
                {"displayFormat", 1},
                {"additionalEmails", additionalEmails}
            };

            Parameter[] p =
            {
                new SimpleParameter("idSite", idSite),
                new SimpleParameter("description", description),
                new PeriodParameter(period),
                new SimpleParameter("hour", hour),
                new SimpleParameter("reportType", reportType.ToString()),
                new SimpleParameter("reportFormat", reportFormat.ToString()),
                new ArrayParameter("reports", includedStatistics.Select(i => i.ToString()).ToArray(), false),
                new DictionaryParameter("parameters", additionalParameters)
            };

            return await ExecuteRequestAsync<int>("addReport", p);
        }

        /// <summary>
        ///     Update an existing scheduled report
        /// </summary>
        /// <param name="idReport">The ID of the report to update</param>
        /// <param name="idSite">ID of the piwik site</param>
        /// <param name="description">Description of the report</param>
        /// <param name="period">A piwik period</param>
        /// <param name="hour">Defines the hour at which the report will be sent</param>
        /// <param name="reportType">The report type</param>
        /// <param name="reportFormat">The report format</param>
        /// <param name="includedStatistics">The included statistics</param>
        /// <param name="emailMe">true if the report should be sent to the own user</param>
        /// <param name="additionalEmails">A string array of additional email recipients</param>
        /// <returns>True if update was successful</returns>
        public async Task<bool> UpdateReportAsync(
            int idReport,
            int idSite,
            string description,
            PiwikPeriod period,
            int hour,
            ReportType reportType,
            ReportFormat reportFormat,
            List<Statistic> includedStatistics,
            bool emailMe,
            string[] additionalEmails = null
            )
        {
            var additionalParameters = new Dictionary<string, object>
            {
                {"emailMe", emailMe.ToString().ToLower()},
                {"displayFormat", 1},
                {"additionalEmails", additionalEmails}
            };

            Parameter[] p =
            {
                new SimpleParameter("idReport", idReport),
                new SimpleParameter("idSite", idSite),
                new SimpleParameter("description", description),
                new PeriodParameter(period),
                new SimpleParameter("hour", hour),
                new SimpleParameter("reportType", reportType.ToString()),
                new SimpleParameter("reportFormat", reportFormat.ToString()),
                new ArrayParameter("reports", includedStatistics.Select(i => i.ToString()).ToArray(), false),
                new DictionaryParameter("parameters", additionalParameters)
            };

            return await ExecuteRequestAsync<bool>("updateReport", p);
        }

        /// <summary>
        ///     Remove a scheduled report
        /// </summary>
        /// <param name="idReport">The ID of the report to delete</param>
        /// <returns>True if the deletion was successful</returns>
        public async Task<bool> DeleteReportAsync(int idReport)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idReport", idReport)
            };

            return await ExecuteRequestAsync<bool>("deleteReport", parameters);
        }
    }
}