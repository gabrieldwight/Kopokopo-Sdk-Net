using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KopokopoSdk.Webhooks
{
    public class SettlementTransferCompleted : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. settlement_transfer_completed in this instance.
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
        public SettlementTransferEvent Event { get; set; }
    }

    public class SettlementTransferEvent
    {
        /// <summary>
        /// The type of transaction (Settlement Transfer)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Settlement Transfer
        /// </summary>
        [JsonProperty("resource")]
        public SettlementTransferEventResource Resource { get; set; }
    }

    public class SettlementTransferEventResource
    {
        /// <summary>
        /// The api reference of the transaction
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The total amount of the transaction
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
        /// The destination of the settlement transfer
        /// </summary>
        [JsonProperty("destination")]
        public Destination Destination { get; set; }

        /// <summary>
        /// These are the disbursements in that particular transfer batch
        /// </summary>
        [JsonProperty("disbursements")]
        public List<Disbursement> Disbursements { get; set; }

        [JsonProperty("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }
    }

    public class Destination
    {
        /// <summary>
        /// The destination type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The destination resource
        /// </summary>
        [JsonProperty("resource")]
        public DestinationResource Resource { get; set; }
    }

    public class DestinationResource
    {
        /// <summary>
        /// The destination reference
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// The name as indicated on the bank account
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// The bank account number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// An identifier identifying the destination bank branch
        /// </summary>
        [JsonProperty("bank_branch_ref")]
        public string BankBranchRef { get; set; }

        /// <summary>
        /// EFT or RTS
        /// </summary>
        [JsonProperty("settlement_method")]
        public string SettlementMethod { get; set; }

        // Mobile wallet
        /// <summary>
        /// First name of the recipient
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of recipient
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Email of recipient
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The mobile network to which the phone number belongs
        /// </summary>
        [JsonProperty("network")]
        public string Network { get; set; }
    }

    public class Disbursement
    {
        /// <summary>
        /// The amount of the disbursement
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The status of the disbursement
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Timestamp of when the transaction took place
        /// </summary>
        [JsonProperty("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        /// <summary>
        /// The reference from the transaction. i.e mpesa reference It is null for eft transactions
        /// </summary>
        [JsonProperty("transaction_reference")]
        public string TransactionReference { get; set; }
    }
}
