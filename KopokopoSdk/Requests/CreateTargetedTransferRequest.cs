using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class CreateTargetedTransferRequest : KopokopoBaseRequest
    {
        [JsonPropertyName("amount")]
        public TargetedTransferAmount Amount { get; set; }

        [JsonPropertyName("destination_type")]
        public string DestinationType { get; set; }

        [JsonPropertyName("destination_reference")]
        public string DestinationReference { get; set; }
    }

    public class TargetedTransferAmount
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
