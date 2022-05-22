using Newtonsoft.Json;
using System;

namespace KopokopoSdk.Webhooks
{
    public class CustomerCreated : WebhookBase
    {
        /// <summary>
        /// The topic of the webhook. customer_created in this instance.
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
        public CustomerCreatedEvent Event { get; set; }
    }

    public class CustomerCreatedEvent
    {
        /// <summary>
        /// The type of record (Mobile Money User)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The resource corresponding to the event. In this case this is a Mobile Money User
        /// </summary>
        [JsonProperty("resource")]
        public CustomerCreatedResource Resource { get; set; }
    }

    public class CustomerCreatedResource
    {
        /// <summary>
        /// Last name of customer
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// First name of customer
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name of customer
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Phone number of customer
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
