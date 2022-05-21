using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class PayRecipientMobileWalletRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("pay_recipient")]
        public MobileWalletPayRecipient PayRecipient { get; set; }
    }

    public class MobileWalletPayRecipient
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }
    }
}
