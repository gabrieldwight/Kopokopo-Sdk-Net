using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class KopokopoApplicationAuthorizationRequest
    {
        /// <summary>
        /// Application key
        /// </summary>
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Application secret. Only revealed to the user when creating an application or during regeneration of client credentials.
        /// </summary>

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }


        [JsonPropertyName("grant_type")]
        [JsonInclude]
        public string GrantType { get; private set; } = "client_credentials";
    }
}
