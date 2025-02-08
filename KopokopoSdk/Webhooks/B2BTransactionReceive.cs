using System;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Webhooks
{
    public class B2BTransactionReceive : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. b2b_transaction_received in this instance.
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
        public B2BEvent Event { get; set; }
    }

    public class B2BEvent
    {
        /// <summary>
        /// The type of transaction (B2b Transaction)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Buygoods Transaction
        /// </summary>
        [JsonPropertyName("resource")]
        public B2BResource Resource { get; set; }
    }

    public class B2BResource
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
        /// The mobile money system
        /// </summary>
        [JsonPropertyName("system")]
        public string System { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The mpesa reference
        /// </summary>
        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// The till number to which the payment was made
        /// </summary>
        [JsonPropertyName("till_number")]
        public string TillNumber { get; set; }

        /// <summary>
        /// The till number of the sender
        /// </summary>
        [JsonPropertyName("sending_till")]
        public string SendingTill { get; set; }

        /// <summary>
        /// The transaction timestamp
        /// </summary>
        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }
    }

}
