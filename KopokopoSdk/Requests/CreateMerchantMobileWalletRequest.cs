using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class CreateMerchantMobileWalletRequest
    {
        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The mobile network to which the phone number belongs
        /// </summary>
        [JsonProperty("network")]
        public string Network { get; set; }
    }
}
