using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class SettlementTransferQueryRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
