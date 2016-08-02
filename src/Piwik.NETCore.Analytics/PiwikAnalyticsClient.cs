using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Piwik.NETCore.Analytics.Parameters;

namespace Piwik.NETCore.Analytics
{
    public interface IPiwikAnalyticsClient
    {
        Uri Uri { get; }
        Task<T> ExecuteRequestAsync<T>(string service, string method, params Parameter[] parameters);
    }

    internal class PiwikAnalyticsClient : IPiwikAnalyticsClient
    {
        public Uri Uri { get; }
        private string _tokenAuth { get; }

        public PiwikAnalyticsClient(Uri uri, string tokenAuth)
        {
            if (uri == null)
            {
                throw new ArgumentException(nameof(uri), @"uri cannot be null");
            }
            
            if (string.IsNullOrWhiteSpace(tokenAuth))
            {
                throw new ArgumentException(nameof(tokenAuth), @"tokenAuth cannot be empty");
            }

            Uri = uri;
            _tokenAuth = tokenAuth;
        }

        public async Task<T> ExecuteRequestAsync<T>(string service, string method, params Parameter[] parameters)
        {
            if (Uri == null)
            {
                throw new ArgumentException(nameof(Uri), @"Url cannot be null");
            }
            
            if (string.IsNullOrWhiteSpace(_tokenAuth))
            {
                throw new ArgumentException(nameof(_tokenAuth), @"tokenAuth cannot be empty");
            }
            
            var uri = BuildUri(service, method, parameters);

            var response = await GetResponse(uri);

            var deserializedObject = JsonConvert.DeserializeObject<T>(response);

            if (deserializedObject == null)
            {
                throw new PiwikApiException(
                    "The server response is not deserializable. " +
                    "Please contact the developer with the following details : response = " + response
                    );
            }

            return deserializedObject;
        }

        private Uri BuildUri(string service, string method, IEnumerable<Parameter> parameters)
        {
            var uriBuilder = new UriBuilder(Uri);

            var defaultParameters = new List<Parameter>
            {
                new SimpleParameter("module", "API"),
                new SimpleParameter("format", "json"),
                new SimpleParameter("token_auth", _tokenAuth),
                new SimpleParameter("method", service + "." + method)
            };

            parameters = (parameters ?? Enumerable.Empty<Parameter>()).Union(defaultParameters).ToList();

            var queryString = parameters.Aggregate(string.Empty, (current, parameter) => current + parameter.Serialize());

            uriBuilder.Query = queryString;

            return uriBuilder.Uri;
        }
        
        private static async Task<string> GetResponse(Uri uri)
        {
            var wc = new HttpClient();
            var response = await wc.GetStringAsync(uri);
            return response;
        }

    }
}