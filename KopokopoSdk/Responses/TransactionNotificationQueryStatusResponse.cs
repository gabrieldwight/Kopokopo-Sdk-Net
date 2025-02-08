using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class TransactionNotificationQueryStatusResponse
    {
        [JsonPropertyName("data")]
        public TransactionNotificationQueryStatusData Data { get; set; }
    }

    public class TransactionNotificationQueryStatusData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public TransactionNotificationQueryStatusAttributes Attributes { get; set; }
    }

    public class TransactionNotificationQueryStatusAttributes : KopokopoBaseResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("webhook_event_reference")]
        public string WebhookEventReference { get; set; }
    }
}
