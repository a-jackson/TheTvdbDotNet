using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class BasicEpisode
    {
        [JsonProperty("absoluteNumber")]
        public int? AbsoluteNumber { get; set; }

        [JsonProperty("airedEpisodeNumber")]
        public int? AiredEpisodeNumber { get; set; }

        [JsonProperty("airedSeason")]
        public int? AiredSeason { get; set; }

        [JsonProperty("dvdEpisodeNumber")]
        public int? DvdEpisodeNumber { get; set; }

        [JsonProperty("dvdSeason")]
        public int? DvdSeason { get; set; }

        [JsonProperty("episodeName")]
        public string EpisodeName { get; set; }

        [JsonProperty("firstAired")]
        public string FirstAired { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("lastUpdated")]
        public long? LastUpdated { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }
    }
}
