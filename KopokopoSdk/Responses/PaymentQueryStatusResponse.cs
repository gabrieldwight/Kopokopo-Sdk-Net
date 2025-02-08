using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class PaymentQueryStatusResponse
    {
        [JsonPropertyName("data")]
        public PaymentQueryStatusData Data { get; set; }
    }

    public class PaymentQueryStatusData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public PaymentQueryStatusAttributes Attributes { get; set; }
    }

    public class PaymentQueryStatusAttributes : KopokopoBaseResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("transfer_batches")]
        public List<PaymentQueryStatusTransferBatch> TransferBatches { get; set; }
    }

    public class PaymentQueryStatusTransferBatch
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("disbursements")]
        public List<PaymentQueryDisbursement> Disbursements { get; set; }
    }

    public class PaymentQueryDisbursement
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("destination_type")]
        public string DestinationType { get; set; }

        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        [JsonPropertyName("destination_reference")]
        public string DestinationReference { get; set; }

        [JsonPropertyName("transaction_reference")]
        public string TransactionReference { get; set; }
    }
}
