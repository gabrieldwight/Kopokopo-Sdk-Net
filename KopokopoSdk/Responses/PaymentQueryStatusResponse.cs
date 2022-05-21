using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KopokopoSdk.Responses
{
    public class PaymentQueryStatusResponse
    {
        [JsonProperty("data")]
        public PaymentQueryStatusData Data { get; set; }
    }

    public class PaymentQueryStatusData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public PaymentQueryStatusAttributes Attributes { get; set; }
    }

    public class PaymentQueryStatusAttributes : KopokopoBaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("transfer_batches")]
        public List<PaymentQueryStatusTransferBatch> TransferBatches { get; set; }
    }

    public class PaymentQueryStatusTransferBatch
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("disbursements")]
        public List<PaymentQueryDisbursement> Disbursements { get; set; }
    }

    public class PaymentQueryDisbursement
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("destination_type")]
        public string DestinationType { get; set; }

        [JsonProperty("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        [JsonProperty("destination_reference")]
        public string DestinationReference { get; set; }

        [JsonProperty("transaction_reference")]
        public string TransactionReference { get; set; }
    }
}
