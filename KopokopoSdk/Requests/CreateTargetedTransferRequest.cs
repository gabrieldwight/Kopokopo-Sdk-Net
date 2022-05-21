using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class CreateTargetedTransferRequest : KopokopoBaseRequest
    {
        [JsonProperty("amount")]
        public TargetedTransferAmount Amount { get; set; }

        [JsonProperty("destination_type")]
        public string DestinationType { get; set; }

        [JsonProperty("destination_reference")]
        public string DestinationReference { get; set; }
    }

    public class TargetedTransferAmount
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
