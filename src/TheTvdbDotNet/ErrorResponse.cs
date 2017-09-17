using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
