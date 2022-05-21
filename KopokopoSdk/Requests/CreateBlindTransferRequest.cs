using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class CreateBlindTransferRequest : KopokopoBaseRequest
    {
        [JsonProperty("amount")]
        public BlindTransferAmount Amount { get; set; }

    }

    public class BlindTransferAmount
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
