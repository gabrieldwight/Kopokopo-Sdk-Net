using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class TransactionSMSNotificationRequest : KopokopoBaseRequest
    {
        [JsonProperty("webhook_event_reference")]
        public string WebhookEventReference { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
