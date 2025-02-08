using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class PollTransactionQueryStatusResponse
    {
        [JsonPropertyName("data")]
        public PollTransactionQueryStatusData Data { get; set; }
    }

    public class PollTransactionQueryStatusData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public PollTransactionQueryStatusAttributes Attributes { get; set; }
    }

    public class PollTransactionQueryStatusAttributes : KopokopoBaseResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("from_time")]
        public DateTimeOffset FromTime { get; set; }

        [JsonPropertyName("to_time")]
        public DateTimeOffset ToTime { get; set; }

        [JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("scope_reference")]
        public object ScopeReference { get; set; }
    }

    public class Transaction
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("resource")]
        public PollTransactionQueryStatusResource Resource { get; set; }
    }

    public class PollTransactionQueryStatusResource
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("system")]
        public string System { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("till_number")]
        public string TillNumber { get; set; }

        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        [JsonPropertyName("sender_last_name")]
        public string SenderLastName { get; set; }

        [JsonPropertyName("sender_first_name")]
        public string SenderFirstName { get; set; }

        [JsonPropertyName("sender_middle_name")]
        public string SenderMiddleName { get; set; }

        [JsonPropertyName("sender_phone_number")]
        public string SenderPhoneNumber { get; set; }
    }
}