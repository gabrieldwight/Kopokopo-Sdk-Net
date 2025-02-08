using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class TransactionSMSNotificationQueryStatusRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
