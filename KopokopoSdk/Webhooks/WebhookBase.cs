using Newtonsoft.Json;

namespace KopokopoSdk.Webhooks
{
    public class WebhookBase
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public class Links
    {
        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }
    }
}