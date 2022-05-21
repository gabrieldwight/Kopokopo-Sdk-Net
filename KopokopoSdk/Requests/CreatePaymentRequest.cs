using Newtonsoft.Json;
using System.Collections.Generic;

namespace KopokopoSdk.Requests
{
    public class CreatePaymentRequest : KopokopoBaseRequest
    {
        [JsonProperty("destination_type")]
        public string DestinationType { get; set; }

        [JsonProperty("destination_reference")]
        public string DestinationReference { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("amount")]
        public CreatePaymentAmount Amount { get; set; }
    }

    public class CreatePaymentAmount
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
