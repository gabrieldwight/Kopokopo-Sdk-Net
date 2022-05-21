using Newtonsoft.Json;

namespace KopokopoSdk.Requests
{
    public class CreateMerchantBankAccountRequest
    {
        /// <summary>
        /// The name as indicated on the bank account name
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// An identifier identifying the destination bank branch.
        /// </summary>
        [JsonProperty("bank_branch_ref")]
        public string BankBranchRef { get; set; }

        /// <summary>
        /// The bank account number
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// EFT or RTS
        /// </summary>
        [JsonProperty("settlement_method")]
        public string SettlementMethod { get; set; }
    }
}
