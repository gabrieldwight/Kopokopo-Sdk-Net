using Newtonsoft.Json;

namespace KopokopoSdk.Responses
{
    public class KopokopoAccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }


        [JsonProperty("token_type")]
        public string TokenType { get; set; }


        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }


        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}
