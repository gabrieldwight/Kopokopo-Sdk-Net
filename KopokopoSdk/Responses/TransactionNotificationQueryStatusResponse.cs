using Newtonsoft.Json;

namespace KopokopoSdk.Responses
{
    public class TransactionNotificationQueryStatusResponse
    {
        [JsonProperty("data")]
        public TransactionNotificationQueryStatusData Data { get; set; }
    }

    public class TransactionNotificationQueryStatusData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public TransactionNotificationQueryStatusAttributes Attributes { get; set; }
    }

    public class TransactionNotificationQueryStatusAttributes : KopokopoBaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("webhook_event_reference")]
        public string WebhookEventReference { get; set; }
    }
}
