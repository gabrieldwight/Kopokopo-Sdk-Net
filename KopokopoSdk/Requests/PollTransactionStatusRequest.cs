using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class PollTransactionStatusRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
