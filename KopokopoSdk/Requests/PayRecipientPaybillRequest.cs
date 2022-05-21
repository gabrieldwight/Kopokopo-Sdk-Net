using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class PayRecipientPaybillRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("pay_recipient")]
        public PaybillPayRecipient PayRecipient { get; set; }
    }

    public class PaybillPayRecipient
    {
        /// <summary>
        /// The name referring to the paybill
        /// </summary>
        [JsonProperty("paybill_name")]
        public string PaybillName { get; set; }

        /// <summary>
        /// The paybill business number
        /// </summary>
        [JsonProperty("paybill_number")]
        public string PaybillNumber { get; set; }

        /// <summary>
        /// The paybill account number
        /// </summary>
        [JsonProperty("paybill_account_number")]
        public string PaybillAccountNumber { get; set; }
    }
}
