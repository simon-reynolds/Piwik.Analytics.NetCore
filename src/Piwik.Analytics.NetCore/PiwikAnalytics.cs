#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Piwik.Analytics.NetCore.Parameters;

namespace Piwik.Analytics.NetCore
{
    public abstract class PiwikAnalytics
    {
        public static string Url;
        
        private string _tokenAuth;

        protected abstract string GetPlugin();

        public void SetTokenAuth(string tokenAuth)
        {
            _tokenAuth = tokenAuth;
        }        

        protected T SendRequest<T>(string method, List<Parameter> parameters)
        {
            Contract.Requires<InvalidOperationException>(string.IsNullOrWhiteSpace(Url));
            Contract.EndContractBlock();

            var uri = BuildUri(method, parameters);

            var response = GetResponse(uri).Result;

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
        
        private Uri BuildUri(string method, IEnumerable<Parameter> parameters)
        {
            var uriBuilder = new UriBuilder(Url);

            var defaultParameters = new List<Parameter>
            {
                new SimpleParameter("module", "API"),
                new SimpleParameter("format", "json"),
                new SimpleParameter("token_auth", _tokenAuth),
                new SimpleParameter("method", GetPlugin() + "." + method)
            };

            parameters = parameters.Union(defaultParameters).ToList();

            var queryString = parameters.Aggregate(string.Empty, (current, parameter) => current + parameter.Serialize());

            uriBuilder.Query = queryString;

            return uriBuilder.Uri;
        }
        
        private async Task<string> GetResponse(Uri uri)
        {
            var wc = new HttpClient();
            var response = await wc.GetStringAsync(uri);
            return response;
        }
    }
}