using Newtonsoft.Json;

namespace TheTvdbDotNet.Authentication
{
    public class LoginRequest
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
}
