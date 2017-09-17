using System;
using Newtonsoft.Json;

namespace TheTvdbDotNet.Authentication
{
    public class Token
    {
        [JsonProperty("exp")]
        public long Expiry { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("orig_iat")]
        public long OriginalIssuedAt { get; set; }

        public DateTime ExpiryDateTime => Expiry.FromUnixTimestamp();

        public DateTime OriginalIssuedAtDateTime => OriginalIssuedAt.FromUnixTimestamp();
    }
}
