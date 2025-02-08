using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class KopokopoAccessTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }


        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }


        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }


        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
    }
}
