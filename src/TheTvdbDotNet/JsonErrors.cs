using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class JsonErrors
    {
        [JsonProperty("")]
        public string[] InvalidFilters { get; set; }

        [JsonProperty("invalidLanguage")]
        public string InvalidLanguage { get; set; }

        [JsonProperty("invalidQueryParams")]
        public string[] InvalidQueryParams { get; set; }
    }
}
