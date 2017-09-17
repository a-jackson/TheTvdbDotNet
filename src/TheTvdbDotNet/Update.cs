using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class Update
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lastUpdated")]
        public int LastUpdated { get; set; }
    }
}
