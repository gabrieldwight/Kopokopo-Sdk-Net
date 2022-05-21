using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KopokopoSdk.Responses
{
    public class PollTransactionQueryStatusResponse
    {
        [JsonProperty("data")]
        public PollTransactionQueryStatusData Data { get; set; }
    }

    public class PollTransactionQueryStatusData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public PollTransactionQueryStatusAttributes Attributes { get; set; }
    }

    public class PollTransactionQueryStatusAttributes : KopokopoBaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("from_time")]
        public DateTimeOffset FromTime { get; set; }

        [JsonProperty("to_time")]
        public DateTimeOffset ToTime { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("scope_reference")]
        public object ScopeReference { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("resource")]
        public PollTransactionQueryStatusResource Resource { get; set; }
    }

    public class PollTransactionQueryStatusResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("till_number")]
        public string TillNumber { get; set; }

        [JsonProperty("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        [JsonProperty("sender_last_name")]
        public string SenderLastName { get; set; }

        [JsonProperty("sender_first_name")]
        public string SenderFirstName { get; set; }

        [JsonProperty("sender_middle_name")]
        public string SenderMiddleName { get; set; }

        [JsonProperty("sender_phone_number")]
        public string SenderPhoneNumber { get; set; }
    }
}