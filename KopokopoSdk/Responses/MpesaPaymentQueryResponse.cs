using Newtonsoft.Json;
using System;

namespace KopokopoSdk.Responses
{
    public class MpesaPaymentQueryResponse
    {
        [JsonProperty("data")]
        public MpesaPaymentQueryData Data { get; set; }
    }

    public class MpesaPaymentQueryData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public MpesaPaymentQueryAttributes Attributes { get; set; }
    }

    public class MpesaPaymentQueryAttributes : KopokopoBaseResponse
    {
        [JsonProperty("initiation_time")]
        public DateTimeOffset InitiationTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }
    }

    public class Event
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("resource")]
        public MpesaPaymentQueryResource Resource { get; set; }

        [JsonProperty("errors")]
        public object Errors { get; set; }
    }

    public class MpesaPaymentQueryResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        [JsonProperty("sender_phone_number")]
        public string SenderPhoneNumber { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("till_number")]
        public string TillNumber { get; set; }

        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("sender_first_name")]
        public string SenderFirstName { get; set; }

        [JsonProperty("sender_middle_name")]
        public object SenderMiddleName { get; set; }

        [JsonProperty("sender_last_name")]
        public string SenderLastName { get; set; }
    }
}
