using Newtonsoft.Json;
using System;

namespace KopokopoSdk.Webhooks
{
    public class BuyGoodsTransactionReceive : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. buygoods_transaction_received in this instance.
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
        public BuyGoodsEvent Event { get; set; }
    }

    public class BuyGoodsEvent
    {
        /// <summary>
        /// The type of transaction (Buygoods Transaction)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Buygoods Transaction
        /// </summary>
        [JsonProperty("resource")]
        public BuyGoodsResource Resource { get; set; }
    }

    public class BuyGoodsResource
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
        /// The mobile money system
        /// </summary>
        [JsonProperty("system")]
        public string System { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The mpesa reference
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// The till number to which the payment was made
        /// </summary>
        [JsonProperty("till_number")]
        public string TillNumber { get; set; }

        /// <summary>
        /// The phone number that sent the payment
        /// </summary>
        [JsonProperty("sender_phone_number")]
        public string SenderPhoneNumber { get; set; }

        /// <summary>
        /// The transaction timestamp
        /// </summary>
        [JsonProperty("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        /// <summary>
        /// Last name of payer
        /// </summary>
        [JsonProperty("sender_last_name")]
        public string SenderLastName { get; set; }

        /// <summary>
        /// First name of payer
        /// </summary>
        [JsonProperty("sender_first_name")]
        public string SenderFirstName { get; set; }

        /// <summary>
        /// Middle name of payer
        /// </summary>
        [JsonProperty("sender_middle_name")]
        public string SenderMiddleName { get; set; }
    }
}
