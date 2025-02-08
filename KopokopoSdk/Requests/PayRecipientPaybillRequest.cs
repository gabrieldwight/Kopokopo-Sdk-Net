using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class PayRecipientPaybillRequest
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("pay_recipient")]
        public PaybillPayRecipient PayRecipient { get; set; }
    }

    public class PaybillPayRecipient
    {
        /// <summary>
        /// The name referring to the paybill
        /// </summary>
        [JsonPropertyName("paybill_name")]
        public string PaybillName { get; set; }

        /// <summary>
        /// The paybill business number
        /// </summary>
        [JsonPropertyName("paybill_number")]
        public string PaybillNumber { get; set; }

        /// <summary>
        /// The paybill account number
        /// </summary>
        [JsonPropertyName("paybill_account_number")]
        public string PaybillAccountNumber { get; set; }
    }
}
