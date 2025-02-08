using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class KopokopoTokenIntrospectionResponse
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("exp")]
        public long Exp { get; set; }

        [JsonPropertyName("iat")]
        public long Iat { get; set; }
    }
}
