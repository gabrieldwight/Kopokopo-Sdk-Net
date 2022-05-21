using Newtonsoft.Json;

namespace KopokopoSdk.Responses
{
    public class KopokopoBaseResponse
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public class Amount
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Links
    {
        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
