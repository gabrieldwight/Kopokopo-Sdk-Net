using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class PayRecipientExternalTillRequest
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("pay_recipient")]
        public ExternalTillPayRecipient PayRecipient { get; set; }
    }

    public class ExternalTillPayRecipient
    {
        /// <summary>
        /// The name as indicated on the till
        /// </summary>
        [JsonPropertyName("till_name")]
        public string TillName { get; set; }

        /// <summary>
        /// The till number
        /// </summary>
        [JsonPropertyName("till_number")]
        public string TillNumber { get; set; }
    }
}
