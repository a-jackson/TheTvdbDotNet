using Newtonsoft.Json;

namespace TheTvdbDotNet
{
    public class UpdateData
    {
        [JsonProperty("data")]
        public Update[] Data { get; set; }

        [JsonProperty("errors")]
        public JsonErrors Errors { get; set; }
    }
}
