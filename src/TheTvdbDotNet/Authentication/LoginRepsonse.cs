using Newtonsoft.Json;

namespace TheTvdbDotNet.Authentication
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
