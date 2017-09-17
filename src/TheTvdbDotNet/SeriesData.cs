using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class SeriesData
    {
        [JsonProperty("data")]
        public Series Data { get; set; }

        [JsonProperty("errors")]
        public JsonErrors Errors { get; set; }

    }
}
