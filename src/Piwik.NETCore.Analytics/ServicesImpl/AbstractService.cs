using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Services;

namespace Piwik.NETCore.Analytics.ServicesImpl
{
    internal abstract class AbstractService<T> where T : IService
    {
        internal abstract IPiwikAnalyticsClient Client { get; }

        public abstract string ServiceName { get; }

        protected async Task<TResult> ExecuteRequestAsync<TResult>(string method, params Parameter[] parameters)
        {
            return await Client.ExecuteRequestAsync<TResult>(ServiceName, method, parameters);
        }
    }
}