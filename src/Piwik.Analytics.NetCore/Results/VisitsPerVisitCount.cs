using Newtonsoft.Json;

namespace Piwik.Analytics.NetCore.Results
{
    public class VisitsPerVisitCount
    {
        [JsonPropertyAttribute("label")]
        public string PagesCount { get; set; }
        
        [JsonPropertyAttribute("nb_visits")]
        public int Visits { get; set; }
        
        [JsonPropertyAttribute("nb_visits_percentage")]
        public string Percentage { get; set; }
    }
}