using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class KopokopoBaseRequest
    {
        /// <summary>
        /// An optional JSON object containing a maximum of 5 key value pairs
        /// </summary>
        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        /// <summary>
        /// A JSON object containing the call back URL where the result of the Incoming Payment will be posted
        /// </summary>
        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
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
