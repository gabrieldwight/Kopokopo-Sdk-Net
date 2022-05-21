using System;

namespace KopokopoSdk
{
    /// <summary>
    /// Strongly typed properties from the Kopokopo API request endpoints
    /// </summary>
    public static class KopokopoRequestEndpoint
    {
        /// <summary>
        /// Sandbox Kopokopo API BaseAdress, use in a development environment
        /// </summary>
        public static Uri SandboxBaseAddress { get; set; } = new Uri("https://sandbox.kopokopo.com/");

        /// <summary>
        /// Live Kopokopo API BaseAdress, use in staging, production  environments
        /// </summary>
        public static Uri LiveBaseAddress { get; set; } = new Uri("https://api.kopokopo.com/");

        /// <summary>
        /// AuthToken Request API Endpoint
        /// </summary>
        public static string OAuthToken { get; set; } = "oauth/token";

        /// <summary>
        /// Revoke AuthToken Request API Endpoint
        /// </summary>
        public static string RevokeOAuthToken { get; set; } = "oauth/revoke";

        /// <summary>
        /// Introspect AuthToken Request API Endpoint
        /// </summary>
        public static string IntrospectOAuthToken { get; set; } = "oauth/introspect";

        /// <summary>
        /// AuthToken Information Request API Endpoint
        /// </summary>
        public static string TokenInformation { get; set; } = "oauth/token/info";

        /// <summary>
        /// Create webhook subscription Request API Endpoint
        /// </summary>
        public static string CreateWebHookSubscription { get; set; } = "api/v1/webhook_subscriptions";

        /// <summary>
        /// Receive payments from M-PESA users via STK Push
        /// </summary>
        public static string ReceiveMpesaPaymentsViaStk { get; set; } = "api/v1/incoming_payments";

        /// <summary>
        /// Query Incoming Payment Status
        /// </summary>
        public static string QueryIncomingPaymentStatus { get; set; } = "api/v1/incoming_payments/";

        /// <summary>
        /// Adding PAY recipients
        /// </summary>
        public static string AddPayRecipient { get; set; } = "api/v1/pay_recipients";

        /// <summary>
        /// Create a payment
        /// </summary>
        public static string CreatePayment { get; set; } = "api/v1/payments";

        /// <summary>
        /// Query payment status
        /// </summary>
        public static string QueryPaymentStatus { get; set; } = "api/v1/payments/";

        /// <summary>
        /// Create a merchant bank account
        /// </summary>
        public static string CreateMerchantBankAccount { get; set; } = "api/v1/merchant_bank_accounts";

        /// <summary>
        /// Create a merchant mobile wallet
        /// </summary>
        public static string CreateMerchantMobileWallet { get; set; } = "api/v1/merchant_wallets";

        /// <summary>
        /// Create a blind transfer
        /// </summary>
        public static string CreateBlindTransfer { get; set; } = "api/v1/settlement_transfers";

        /// <summary>
        /// Create a targeted transfer
        /// </summary>
        public static string CreateTargetedTransfer { get; set; } = "api/v1/settlement_transfers";

        /// <summary>
        /// Query transfer status
        /// </summary>
        public static string QueryTransferStatus { get; set; } = "api/v1/settlement_transfers/";

        /// <summary>
        /// Polling
        /// </summary>
        public static string Polling { get; set; } = "api/v1/polling";

        /// <summary>
        /// Query Polling Status
        /// </summary>
        public static string QueryPollingStatus { get; set; } = "api/v1/polling/";

        /// <summary>
        /// Transaction SMS Notifications
        /// </summary>
        public static string TransactionSMSNotifications { get; set; } = "api/v1/transaction_sms_notifications";

        /// <summary>
        /// Query Transaction Notification API Status
        /// </summary>
        public static string QueryTransactionSMSStatus { get; set; } = "api/v1/transaction_sms_notifications/";
    }
}
