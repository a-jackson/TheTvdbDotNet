using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class SeriesEpisodes
    {
        [JsonProperty("data")]
        public BasicEpisode[] Data { get; set; }

        [JsonProperty("errrors")]
        public JsonErrors Errors { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }
}
