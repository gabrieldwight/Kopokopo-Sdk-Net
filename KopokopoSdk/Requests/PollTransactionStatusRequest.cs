using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class PollTransactionStatusRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
