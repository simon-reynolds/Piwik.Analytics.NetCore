using Newtonsoft.Json;

namespace Piwik.NETCore.Analytics.Results
{
    public class VisitsPerPage
    {
        [JsonPropertyAttribute("label")]
        public string PagesCount { get; set; }
        
        [JsonPropertyAttribute("nb_visits")]
        public int Visits { get; set; }
    }
}