using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class KopokopoTokenInformationResponse
    {
        [JsonPropertyName("resource_owner_id")]
        public object ResourceOwnerId { get; set; }

        [JsonPropertyName("scope")]
        public List<object> Scope { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonPropertyName("application")]
        public Application Application { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
    }

    public class Application
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }
    }
}
