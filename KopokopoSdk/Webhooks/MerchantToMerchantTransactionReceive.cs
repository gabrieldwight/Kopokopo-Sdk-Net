using System;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Webhooks
{
    public class MerchantToMerchantTransactionReceive : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. m2m_transaction_received in this instance.
        /// </summary>
        [JsonPropertyName("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// The ID of the Webhook Event
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The timestamp of when the webhook event was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("event")]
        public MerchantToMerchantEvent Event { get; set; }
    }

    public class MerchantToMerchantEvent
    {
        /// <summary>
        /// The type of transaction (Merchant to Merchant Transaction)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Merchant to Merchant Transaction
        /// </summary>
        [JsonPropertyName("resource")]
        public MerchantToMerchantResource Resource { get; set; }
    }

    public class MerchantToMerchantResource
    {
        /// <summary>
        /// The api reference of the transaction
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The amount of the transaction
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The status of the transaction
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The transaction timestamp
        /// </summary>
        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        /// <summary>
        /// Name of merchant
        /// </summary>
        [JsonPropertyName("sending_merchant")]
        public string SendingMerchant { get; set; }
    }
}
