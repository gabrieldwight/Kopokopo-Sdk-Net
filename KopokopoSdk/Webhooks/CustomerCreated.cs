using System;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Webhooks
{
    public class CustomerCreated : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. customer_created in this instance.
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
        public CustomerCreatedEvent Event { get; set; }
    }

    public class CustomerCreatedEvent
    {
        /// <summary>
        /// The type of record (Mobile Money User)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Mobile Money User
        /// </summary>
        [JsonPropertyName("resource")]
        public CustomerCreatedResource Resource { get; set; }
    }

    public class CustomerCreatedResource
    {
        /// <summary>
        /// Last name of customer
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// First name of customer
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name of customer
        /// </summary>
        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Phone number of customer
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
