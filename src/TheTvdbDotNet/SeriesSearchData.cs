using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class SeriesSearchData
    {
        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("firstAired")]
        public string FirstAired { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("seriesName")]
        public string SeriesName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
