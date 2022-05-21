using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class KopokopoAccessTokenRequest
    {
        /// <summary>
        /// Application key
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Application secret. Only revealed to the user when creating an application or during regeneration of client credentials.
        /// </summary>

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// The access token belonging to the application that is to be revoked.
        /// </summary>
        [JsonProperty("grant_type")]
        public string Token { get; set; }
    }
}
