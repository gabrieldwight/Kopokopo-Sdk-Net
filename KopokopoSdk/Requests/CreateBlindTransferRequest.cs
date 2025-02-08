using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class CreateBlindTransferRequest : KopokopoBaseRequest
    {
        [JsonPropertyName("amount")]
        public BlindTransferAmount Amount { get; set; }

    }

    public class BlindTransferAmount
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
