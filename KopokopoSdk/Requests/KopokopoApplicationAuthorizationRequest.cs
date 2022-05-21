using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class KopokopoApplicationAuthorizationRequest
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


        [JsonProperty("grant_type")]
        public string GrantType { get; private set; } = "client_credentials";
    }
}
