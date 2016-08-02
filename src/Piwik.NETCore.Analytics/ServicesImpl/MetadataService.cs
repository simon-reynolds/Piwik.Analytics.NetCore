using System;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Services;

namespace Piwik.NETCore.Analytics.ServicesImpl
{
    internal class MetadataService : AbstractService<IMetadataService>, IMetadataService
    {
        internal override IPiwikAnalyticsClient Client { get; }

        public override string ServiceName { get; } = "API";

        internal MetadataService(IPiwikAnalyticsClient client)
        {
            Client = client;
        }

        public Task<object> GetPiwikVersionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetIpFromHeaderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSettingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSegmentsMetadataAsync(int[] idSites)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetBulkRequestAsync(string[] urls)
        {
            throw new NotImplementedException();
        }

        public Task<object> IsPluginActivatedAsync(string pluginName)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSuggestedValuesForSegmentAsync(string segmentName, int idSite)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetGlossaryReportsAsync(int idSite)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetGlossaryMetricsAsync(int idSite)
        {
            throw new NotImplementedException();
        }
    }
}