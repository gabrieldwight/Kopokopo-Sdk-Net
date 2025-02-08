using System;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class MpesaPaymentQueryResponse
    {
        [JsonPropertyName("data")]
        public MpesaPaymentQueryData Data { get; set; }
    }

    public class MpesaPaymentQueryData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public MpesaPaymentQueryAttributes Attributes { get; set; }
    }

    public class MpesaPaymentQueryAttributes : KopokopoBaseResponse
    {
        [JsonPropertyName("initiation_time")]
        public DateTimeOffset InitiationTime { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("event")]
        public Event Event { get; set; }
    }

    public class Event
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("resource")]
        public MpesaPaymentQueryResource Resource { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }
    }

    public class MpesaPaymentQueryResource
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("origination_time")]
        public DateTimeOffset OriginationTime { get; set; }

        [JsonPropertyName("sender_phone_number")]
        public string SenderPhoneNumber { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("till_number")]
        public string TillNumber { get; set; }

        [JsonPropertyName("system")]
        public string System { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("sender_first_name")]
        public string SenderFirstName { get; set; }

        [JsonPropertyName("sender_middle_name")]
        public object SenderMiddleName { get; set; }

        [JsonPropertyName("sender_last_name")]
        public string SenderLastName { get; set; }
    }
}
