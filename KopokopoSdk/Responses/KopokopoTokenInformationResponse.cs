using Newtonsoft.Json;
using System.Collections.Generic;

namespace KopokopoSdk.Responses
{
    public class KopokopoTokenInformationResponse
    {
        [JsonProperty("resource_owner_id")]
        public object ResourceOwnerId { get; set; }

        [JsonProperty("scope")]
        public List<object> Scope { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }

    public class Application
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
    }
}
