using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class KopokopoAccessTokenRequest
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

        /// <summary>
        /// The access token belonging to the application that is to be revoked.
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
