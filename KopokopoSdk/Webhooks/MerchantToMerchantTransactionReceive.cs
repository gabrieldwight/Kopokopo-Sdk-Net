using Newtonsoft.Json;
using System;

namespace KopokopoSdk.Webhooks
{
    public class MerchantToMerchantTransactionReceive : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. m2m_transaction_received in this instance.
        /// </summary>
        [JsonProperty("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// The ID of the Webhook Event
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The timestamp of when the webhook event was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("event")]
        public MerchantToMerchantEvent Event { get; set; }
    }

    public class MerchantToMerchantEvent
    {
        /// <summary>
        /// The type of transaction (Merchant to Merchant Transaction)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Merchant to Merchant Transaction
        /// </summary>
        [JsonProperty("resource")]
        public MerchantToMerchantResource Resource { get; set; }
    }

    public class MerchantToMerchantResource
    {
        /// <summary>
        /// The api reference of the transaction
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The amount of the transaction
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The status of the transaction
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The transaction timestamp
        /// </summary>
        [JsonProperty("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        /// <summary>
        /// Name of merchant
        /// </summary>
        [JsonProperty("sending_merchant")]
        public string SendingMerchant { get; set; }
    }
}
