using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class PayRecipientMobileWalletRequest
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("pay_recipient")]
        public MobileWalletPayRecipient PayRecipient { get; set; }
    }

    public class MobileWalletPayRecipient
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("network")]
        public string Network { get; set; }
    }
}
