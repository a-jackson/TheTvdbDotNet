using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class Links
    {
        [JsonProperty("first")]
        public int? First { get; set; }

        [JsonProperty("last")]
        public int? Last { get; set; }

        [JsonProperty("next")]
        public int? Next { get; set; }

        [JsonProperty("previous")]
        public int? Previous { get; set; }
    }
}
