using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class KopokopoBaseRequest
    {
        /// <summary>
        /// An optional JSON object containing a maximum of 5 key value pairs
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        /// <summary>
        /// A JSON object containing the call back URL where the result of the Incoming Payment will be posted
        /// </summary>
        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public class Links
    {
        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }
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
