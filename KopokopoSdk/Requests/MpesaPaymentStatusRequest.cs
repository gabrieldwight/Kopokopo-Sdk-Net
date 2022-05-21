using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class MpesaPaymentStatusRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
