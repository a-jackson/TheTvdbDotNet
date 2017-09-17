using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class SeriesSearch
    {
        [JsonProperty("data")]
        public SeriesSearchData[] Data { get; set; }
    }
}
