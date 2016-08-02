using System.Threading.Tasks;

namespace Piwik.NETCore.Analytics.Services
{
    public interface IMetadataService : IService
    {
        Task<object> GetPiwikVersionAsync();
        Task<object> GetIpFromHeaderAsync();
        Task<object> GetSettingsAsync();
        Task<object> GetSegmentsMetadataAsync(int[] idSites);
        //Task<object> GetMetadataAsync(int idSite, apiModule, apiAction, apiParameters = 'Array', language = null, period = null, date = null, hideMetricsDoc = null, showSubtableReports = null);
        //Task<object> GetReportMetadataAsync(int idSites = null, period = null, date = null, hideMetricsDoc = null, showSubtableReports = null);
        //Task<object> GetProcessedReportAsync(int idSite, PiwikPeriod period, IPiwikDate date, apiModule, apiAction, string segment = null, apiParameters = null, idGoal = null, language = null, showTimer = '1', hideMetricsDoc = null, idSubtable = null, showRawMetrics = null, format_metrics = null, idDimension = null);
        //Task<object> GetAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null, columns = null);
        //Task<object> GetRowEvolutionAsync(int idSite, PiwikPeriod period, IPiwikDate date, apiModule, apiAction, label = null, string segment = null, column = null, language = null, idGoal = null, legendAppendMetric = '1', labelUseAbsoluteUrl = '1', idDimension = null);
        Task<object> GetBulkRequestAsync(string[] urls);
        Task<object> IsPluginActivatedAsync(string pluginName);
        Task<object> GetSuggestedValuesForSegmentAsync(string segmentName, int idSite);
        Task<object> GetGlossaryReportsAsync(int idSite);
        Task<object> GetGlossaryMetricsAsync(int idSite);
    }
}