using Newtonsoft.Json;

namespace KopokopoSdk.Responses
{
    public class KopokopoTokenIntrospectionResponse
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("exp")]
        public long Exp { get; set; }

        [JsonProperty("iat")]
        public long Iat { get; set; }
    }
}
