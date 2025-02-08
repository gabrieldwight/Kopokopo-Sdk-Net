using System;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Webhooks
{
    public class BuyGoodsTransactionReversed : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. buygoods_transaction_reversed in this instance.
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
        public BuyGoodsReversedEvent Event { get; set; }
    }

    public class BuyGoodsReversedEvent
    {
        /// <summary>
        /// The type of transaction (Buygoods Transaction)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Buygoods Transaction
        /// </summary>
        [JsonPropertyName("resource")]
        public BuyGoodsReversedResource Resource { get; set; }
    }

    public class BuyGoodsReversedResource
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
        /// The transaction timestamp
        /// </summary>
        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        /// <summary>
        /// Last name of payer
        /// </summary>
        [JsonPropertyName("sender_last_name")]
        public string SenderLastName { get; set; }

        /// <summary>
        /// First name of payer
        /// </summary>
        [JsonPropertyName("sender_first_name")]
        public string SenderFirstName { get; set; }

        /// <summary>
        /// Middle name of payer
        /// </summary>
        [JsonPropertyName("sender_middle_name")]
        public string SenderMiddleName { get; set; }

        /// <summary>
        /// The phone number that sent the payment
        /// </summary>
        [JsonPropertyName("sender_phone_number")]
        public string SenderPhoneNumber { get; set; }
    }
}
