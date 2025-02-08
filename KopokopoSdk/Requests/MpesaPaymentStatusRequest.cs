using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class MpesaPaymentStatusRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
