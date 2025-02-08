using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class TransactionSMSNotificationRequest : KopokopoBaseRequest
    {
        [JsonPropertyName("webhook_event_reference")]
        public string WebhookEventReference { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
