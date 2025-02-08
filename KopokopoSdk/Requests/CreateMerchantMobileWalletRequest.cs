using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class CreateMerchantMobileWalletRequest
    {
        /// <summary>
        /// First Name
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The mobile network to which the phone number belongs
        /// </summary>
        [JsonPropertyName("network")]
        public string Network { get; set; }
    }
}
