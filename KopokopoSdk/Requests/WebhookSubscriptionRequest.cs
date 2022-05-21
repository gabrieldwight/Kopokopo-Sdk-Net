using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class WebhookSubscriptionRequest
    {
        /// <summary>
        /// The type of event you are subscribing to. Should be one of: buygoods_transaction_received, buygoods_transaction_reversed, b2b_transaction_received, m2m_transaction_received,settlement_transfer_completed, customer_created
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        /// <summary>
        /// The http end point to send the webhook. MUST be secured with HTTPS (TLS)
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The scope of the webhook subscription. Could be either company or till
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// If the scope is till the scope reference is required and it should be your till number
        /// </summary>
        [JsonProperty("scope_reference")]
        public string ScopeReference { get; set; }
    }
}
