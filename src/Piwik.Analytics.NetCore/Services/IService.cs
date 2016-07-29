using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.NETCore.Analytics.Date;
using Piwik.NETCore.Analytics.Parameters;
using Piwik.NETCore.Analytics.Results;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>

namespace Piwik.NETCore.Analytics.Services
{
    public interface IService
    {
        string ServiceName { get; }
    }

    public abstract class AbstractService<T> where T : IService
    {
        protected abstract PiwikAnalyticsClient Client { get; }

        public abstract string ServiceName { get; }

        protected async Task<TResult> ExecuteRequestAsync<TResult>(string method, params Parameter[] parameters)
        {
            return await Client.SendRequestAsync<TResult>(ServiceName, method, parameters);
        }
    }
}