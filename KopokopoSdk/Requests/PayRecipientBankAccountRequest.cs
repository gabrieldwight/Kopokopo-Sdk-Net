using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class PayRecipientBankAccountRequest
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("pay_recipient")]
        public BankAccountPayRecipient PayRecipient { get; set; }
    }

    public class BankAccountPayRecipient
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

        [JsonPropertyName("settlement_method")]
        public string SettlementMethod { get; set; } = "RTS";
    }
}
