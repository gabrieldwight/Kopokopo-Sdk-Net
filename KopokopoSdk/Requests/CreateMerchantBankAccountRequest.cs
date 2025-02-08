using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class CreateMerchantBankAccountRequest
    {
        /// <summary>
        /// The name as indicated on the bank account name
        /// </summary>
        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// An identifier identifying the destination bank branch.
        /// </summary>
        [JsonPropertyName("bank_branch_ref")]
        public string BankBranchRef { get; set; }

        /// <summary>
        /// The bank account number
        /// </summary>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// EFT or RTS
        /// </summary>
        [JsonPropertyName("settlement_method")]
        public string SettlementMethod { get; set; }
    }
}
