using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class TransferQueryStatusResponse
    {
        [JsonPropertyName("data")]
        public TransferQueryStatusData Data { get; set; }
    }

    public class TransferQueryStatusData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public TransferQueryStatusAttributes Attributes { get; set; }
    }

    public class TransferQueryStatusAttributes : KopokopoBaseResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("transfer_batches")]
        public List<TransferQueryStatusTransferBatch> TransferBatches { get; set; }
    }

    public class TransferQueryStatusTransferBatch
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("disbursements")]
        public List<TransferQueryStatusDisbursement> Disbursements { get; set; }
    }

    public class TransferQueryStatusDisbursement
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
