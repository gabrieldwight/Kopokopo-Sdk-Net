using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class TransactionSMSNotificationQueryStatusRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
