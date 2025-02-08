using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class KopokopoBaseResponse
    {
        [JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }

    public class Amount
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonPropertyName("self")]
        public string Self { get; set; }
    }

    public class Metadata
    {
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }
}
