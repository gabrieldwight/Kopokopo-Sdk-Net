using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class PayRecipientExternalTillRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("pay_recipient")]
        public ExternalTillPayRecipient PayRecipient { get; set; }
    }

    public class ExternalTillPayRecipient
    {
        /// <summary>
        /// The name as indicated on the till
        /// </summary>
        [JsonProperty("till_name")]
        public string TillName { get; set; }

        /// <summary>
        /// The till number
        /// </summary>
        [JsonProperty("till_number")]
        public string TillNumber { get; set; }
    }
}
