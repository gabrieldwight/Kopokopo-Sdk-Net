using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Webhooks
{
    public class SettlementTransferCompleted : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. settlement_transfer_completed in this instance.
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
        public SettlementTransferEvent Event { get; set; }
    }

    public class SettlementTransferEvent
    {
        /// <summary>
        /// The type of transaction (Settlement Transfer)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Settlement Transfer
        /// </summary>
        [JsonPropertyName("resource")]
        public SettlementTransferEventResource Resource { get; set; }
    }

    public class SettlementTransferEventResource
    {
        /// <summary>
        /// The api reference of the transaction
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The total amount of the transaction
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
        /// The destination of the settlement transfer
        /// </summary>
        [JsonPropertyName("destination")]
        public Destination Destination { get; set; }

        /// <summary>
        /// These are the disbursements in that particular transfer batch
        /// </summary>
        [JsonPropertyName("disbursements")]
        public List<Disbursement> Disbursements { get; set; }

        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }
    }

    public class Destination
    {
        /// <summary>
        /// The destination type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The destination resource
        /// </summary>
        [JsonPropertyName("resource")]
        public DestinationResource Resource { get; set; }
    }

    public class DestinationResource
    {
        /// <summary>
        /// The destination reference
        /// </summary>
        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// The name as indicated on the bank account
        /// </summary>
        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// The bank account number
        /// </summary>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// An identifier identifying the destination bank branch
        /// </summary>
        [JsonPropertyName("bank_branch_ref")]
        public string BankBranchRef { get; set; }

        /// <summary>
        /// EFT or RTS
        /// </summary>
        [JsonPropertyName("settlement_method")]
        public string SettlementMethod { get; set; }

        // Mobile wallet
        /// <summary>
        /// First name of the recipient
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of recipient
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Email of recipient
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The mobile network to which the phone number belongs
        /// </summary>
        [JsonPropertyName("network")]
        public string Network { get; set; }
    }

    public class Disbursement
    {
        /// <summary>
        /// The amount of the disbursement
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The status of the disbursement
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Timestamp of when the transaction took place
        /// </summary>
        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        /// <summary>
        /// The reference from the transaction. i.e mpesa reference It is null for eft transactions
        /// </summary>
        [JsonPropertyName("transaction_reference")]
        public string TransactionReference { get; set; }
    }
}
