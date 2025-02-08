using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class CreatePaymentRequest : KopokopoBaseRequest
    {
        [JsonPropertyName("destination_type")]
        public string DestinationType { get; set; }

        [JsonPropertyName("destination_reference")]
        public string DestinationReference { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("amount")]
        public CreatePaymentAmount Amount { get; set; }
    }

    public class CreatePaymentAmount
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}
