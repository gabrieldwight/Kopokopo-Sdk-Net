using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class CreatePaymentStatusRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
