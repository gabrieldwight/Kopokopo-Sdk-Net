using KopokopoSdk.Requests;
using KopokopoSdk.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace KopokopoSdk.Interfaces
{
    /// <summary>
    /// IKopokopo Interface
    /// </summary>
    /// <remarks>
    /// Provides all the Methods implemented by Kopokopo Class. 
    /// A developer can create their own implementation for example for tests/mocks by inheriting from this interface.
    /// </remarks>
    public interface IKopokopoClient
    {
        /// <summary>
        /// The client credentials flow is the simplest OAuth 2 grant, with a server-to-server exchange of your application’s client_id, client_secret for an OAuth application access token. In order to execute this flow, you will need to make an HTTP request from your application server, to the Kopo Kopo authorization server.
        /// </summary>
        /// <param name="kopokopoApplicationAuthorizationRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        Task<KopokopoAccessTokenResponse> GetOAuthTokenAsync(KopokopoApplicationAuthorizationRequest kopokopoApplicationAuthorizationRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// The client credentials flow is the simplest OAuth 2 grant, with a server-to-server exchange of your application’s client_id, client_secret for an OAuth application access token. In order to execute this flow, you will need to make an HTTP request from your application server, to the Kopo Kopo authorization server.
        /// </summary>
        /// <param name="kopokopoApplicationAuthorizationRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        KopokopoAccessTokenResponse GetOAuthToken(KopokopoApplicationAuthorizationRequest kopokopoApplicationAuthorizationRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// The request is used to revoke a particular token at a time.
        /// </summary>
        /// <param name="kopokopoAccessTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        Task<string> RevokeOAuthTokenAsync(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// The request is used to revoke a particular token at a time.
        /// </summary>
        /// <param name="kopokopoAccessTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        string RevokeOAuthToken(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// It can be used to check the validity of your access tokens, and find out other information such as which user and which scopes are associated with the token. The client secret will not be displayed as that is to remain confidential with the application owner.
        /// </summary>
        /// <param name="kopokopoAccessTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        Task<KopokopoTokenIntrospectionResponse> GetTokenIntrospectionAsync(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// It can be used to check the validity of your access tokens, and find out other information such as which user and which scopes are associated with the token. The client secret will not be displayed as that is to remain confidential with the application owner.
        /// </summary>
        /// <param name="kopokopoAccessTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        KopokopoTokenIntrospectionResponse GetTokenIntrospection(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Shows details about the token used for authentication.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        Task<KopokopoTokenInformationResponse> GetTokenInformationAsync(string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Shows details about the token used for authentication.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <returns></returns>
        KopokopoTokenInformationResponse GetTokenInformation(string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Webhooks are a means of getting notified of events in the Kopo Kopo application. To receive webhooks, you need to create a webhook subscription.
        /// </summary>
        /// <param name="webhookSubscriptionRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CreateWebhookSubscriptionAsync(WebhookSubscriptionRequest webhookSubscriptionRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Webhooks are a means of getting notified of events in the Kopo Kopo application. To receive webhooks, you need to create a webhook subscription.
        /// </summary>
        /// <param name="webhookSubscriptionRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string CreateWebhookSubscription(WebhookSubscriptionRequest webhookSubscriptionRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Receive payments from M-PESA users via STK Push.
        /// </summary>
        /// <param name="mpesaPaymentRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> ReceiveMpesaPaymentAsync(MpesaPaymentRequest mpesaPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Receive payments from M-PESA users via STK Push.
        /// </summary>
        /// <param name="mpesaPaymentRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string ReceiveMpesaPayment(MpesaPaymentRequest mpesaPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// With an Incoming Payment location url, you can query what the status of the Incoming Payment is. If a corresponding Incoming Payment Result exists, it will be bundled in the payload of the result.
        /// </summary>
        /// <param name="mpesaPaymentStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MpesaPaymentQueryResponse> QueryMpesaPaymentAsync(MpesaPaymentStatusRequest mpesaPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// With an Incoming Payment location url, you can query what the status of the Incoming Payment is. If a corresponding Incoming Payment Result exists, it will be bundled in the payload of the result.
        /// </summary>
        /// <param name="mpesaPaymentStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        MpesaPaymentQueryResponse QueryMpesaPayment(MpesaPaymentStatusRequest mpesaPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="payRecipientMobileWalletRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PayRecipientMobileWalletAsync(PayRecipientMobileWalletRequest payRecipientMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="payRecipientMobileWalletRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string PayRecipientMobileWallet(PayRecipientMobileWalletRequest payRecipientMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="payRecipientBankAccountRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PayRecipientBankAccountAsync(PayRecipientBankAccountRequest payRecipientBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="paymentBankAccountRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string PayRecipientBankAccount(PayRecipientBankAccountRequest paymentBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="payRecipientExternalTillRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PayRecipientExternalTillAsync(PayRecipientExternalTillRequest payRecipientExternalTillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="payRecipientExternalTillRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string PayRecipientExternalTill(PayRecipientExternalTillRequest payRecipientExternalTillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="payRecipientPaybillRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PayRecipientPaybillAsync(PayRecipientPaybillRequest payRecipientPaybillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add external entities that will be the destination of your payments.
        /// </summary>
        /// <param name="payRecipientPaybillRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string PayRecipientPaybill(PayRecipientPaybillRequest payRecipientPaybillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create an outgoing payment to a third party. The final result of the Payment will be posted asynchronously to your systems via the call back URL provided in the request.
        /// </summary>
        /// <param name="createPaymentRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CreatePaymentAsync(CreatePaymentRequest createPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create an outgoing payment to a third party. The final result of the Payment will be posted asynchronously to your systems via the call back URL provided in the request.
        /// </summary>
        /// <param name="createPaymentRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string CreatePayment(CreatePaymentRequest createPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query the status of a previously initiated Payment request
        /// </summary>
        /// <param name="createPaymentStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PaymentQueryStatusResponse> QueryPaymentStatusAsync(CreatePaymentStatusRequest createPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query the status of a previously initiated Payment request
        /// </summary>
        /// <param name="createPaymentStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        PaymentQueryStatusResponse QueryPaymentStatus(CreatePaymentStatusRequest createPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Transfer funds to your pre-approved settlement accounts (bank accounts or mobile wallets).
        /// </summary>
        /// <param name="createMerchantBankAccountRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CreateMerchantBankAccountAsync(CreateMerchantBankAccountRequest createMerchantBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Transfer funds to your pre-approved settlement accounts (bank accounts or mobile wallets).
        /// </summary>
        /// <param name="createMerchantBankAccountRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string CreateMerchantBankAccount(CreateMerchantBankAccountRequest createMerchantBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Transfer funds to your pre-approved settlement accounts (bank accounts or mobile wallets).
        /// </summary>
        /// <param name="createMerchantMobileWalletRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CreateMerchantMobileWalletAsync(CreateMerchantMobileWalletRequest createMerchantMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Transfer funds to your pre-approved settlement accounts (bank accounts or mobile wallets).
        /// </summary>
        /// <param name="createMerchantMobileWalletRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string CreateMerchantMobileWallet(CreateMerchantMobileWalletRequest createMerchantMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a transfer by specifying the amount but NOT the destination. Your preferred settlement location(s) that are linked to your company and tills will be used as the destination.
        /// </summary>
        /// <param name="createBlindTransferRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CreateBlindTransferAsync(CreateBlindTransferRequest createBlindTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a transfer by specifying the amount but NOT the destination. Your preferred settlement location(s) that are linked to your company and tills will be used as the destination.
        /// </summary>
        /// <param name="createBlindTransferRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string CreateBlindTransfer(CreateBlindTransferRequest createBlindTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a transfer from your Kopo Kopo account by specifying the destination of the funds.
        /// </summary>
        /// <param name="createTargetedTransferRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CreateTargetedTransferAsync(CreateTargetedTransferRequest createTargetedTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a transfer from your Kopo Kopo account by specifying the destination of the funds.
        /// </summary>
        /// <param name="createTargetedTransferRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string CreateTargetedTransfer(CreateTargetedTransferRequest createTargetedTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check the status of a prior initiated Settlement Transfer.
        /// </summary>
        /// <param name="settlementTransferQueryRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TransferQueryStatusResponse> QueryTransferStatusAsync(SettlementTransferQueryRequest settlementTransferQueryRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check the status of a prior initiated Settlement Transfer.
        /// </summary>
        /// <param name="settlementTransferQueryRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        TransferQueryStatusResponse QueryTransferStatus(SettlementTransferQueryRequest settlementTransferQueryRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Poll Buygoods Transactions between the specified dates for a particular till or for the whole company
        /// </summary>
        /// <param name="pollingRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> PollTransactionsAsync(PollTransactionRequest pollingRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Poll Buygoods Transactions between the specified dates for a particular till or for the whole company
        /// </summary>
        /// <param name="pollingRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string PollTransactions(PollTransactionRequest pollingRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// With an Polling location url, you can query what the status of the Polling API is. If a corresponding Polling Result exists, it will be bundled in the payload of the result.
        /// </summary>
        /// <param name="pollingStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PollTransactionQueryStatusResponse> QueryPollTransactionStatusAsync(PollTransactionStatusRequest pollingStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// With an Polling location url, you can query what the status of the Polling API is. If a corresponding Polling Result exists, it will be bundled in the payload of the result.
        /// </summary>
        /// <param name="pollingStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        PollTransactionQueryStatusResponse QueryPollTransactionStatus(PollTransactionStatusRequest pollingStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send sms notifications to your customer after you have received a payment from them.
        /// </summary>
        /// <param name="transactionSMSNotificationRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> TransactionSMSNotificationAsync(TransactionSMSNotificationRequest transactionSMSNotificationRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send sms notifications to your customer after you have received a payment from them.
        /// </summary>
        /// <param name="transactionSMSNotificationRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        string TransactionSMSNotification(TransactionSMSNotificationRequest transactionSMSNotificationRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// With an Transaction Sms Notification location url, you can query what the status of the Transaction Notification is. If a corresponding Transaction Sms Notification Result exists, it will be bundled in the payload of the result.
        /// </summary>
        /// <param name="transactionSMSNotificationQueryStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TransactionNotificationQueryStatusResponse> QueryTransactionSMSNotificationStatusAsync(TransactionSMSNotificationQueryStatusRequest transactionSMSNotificationQueryStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);

        /// <summary>
        /// With an Transaction Sms Notification location url, you can query what the status of the Transaction Notification is. If a corresponding Transaction Sms Notification Result exists, it will be bundled in the payload of the result.
        /// </summary>
        /// <param name="transactionSMSNotificationQueryStatusRequest"></param>
        /// <param name="accessToken"></param>
        /// <param name="kopokopoRequestEndpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        TransactionNotificationQueryStatusResponse QueryTransactionSMSNotificationStatus(TransactionSMSNotificationQueryStatusRequest transactionSMSNotificationQueryStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default);
    }
}
