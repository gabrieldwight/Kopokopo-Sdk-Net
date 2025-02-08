using System.Text.Json.Serialization;

namespace KopokopoSdk.Webhooks
{
    public class WebhookBase
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }

        [JsonPropertyName("resource")]
        public string Resource { get; set; }
    }
}