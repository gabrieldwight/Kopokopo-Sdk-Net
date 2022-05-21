using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class MpesaPaymentRequest : KopokopoBaseRequest
    {
        /// <summary>
        /// The payment channel to be used eg. M-PESA
        /// </summary>
        [JsonProperty("payment_channel")]
        public string PaymentChannel { get; set; }

        /// <summary>
        /// The online payments till number from the Kopo Kopo dashboard to which the payment will be made
        /// </summary>

        [JsonProperty("till_number")]
        public string TillNumber { get; set; }

        /// <summary>
        /// A Subscriber JSON object see below
        /// </summary>
        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        /// <summary>
        /// An Amount JSON object containing currency and amount
        /// </summary>

        [JsonProperty("amount")]
        public MpesaPaymentAmount Amount { get; set; }
    }

    public class MpesaPaymentAmount
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public class Subscriber
    {
        /// <summary>
        /// First name of the subscriber
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the subscriber
        /// </summary>

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number of the subscriber from which the payment will be made
        /// </summary>

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// E-mail address of the subscriber - optional
        /// </summary>

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
