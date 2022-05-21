using KopokopoSdk.Exceptions;
using KopokopoSdk.Interfaces;
using KopokopoSdk.Requests;
using KopokopoSdk.Responses;
using KopokopoSdk.Validators;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Polly;
using Polly.Extensions.Http;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KopokopoSdk
{
    public  class KopokopoClient : IKopokopoClient
    {
        private readonly HttpClient _client;
        readonly Random jitterer = new Random();
        private readonly JsonSerializer _serializer = new JsonSerializer();

        public KopokopoClient(Enums.Environment environment)
        {
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(1, retryAttempt =>
                {
                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(jitterer.Next(0, 100));
                });

            var noOpPolicy = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

            var services = new ServiceCollection();
            services.AddHttpClient("KopokopoApiClient", client =>
            {
                switch (environment)
                {
                    case Enums.Environment.Sandbox:
                        client.BaseAddress = KopokopoRequestEndpoint.SandboxBaseAddress;
                        client.Timeout = TimeSpan.FromMinutes(10);
                        break;

                    case Enums.Environment.Live:
                        client.BaseAddress = KopokopoRequestEndpoint.LiveBaseAddress;
                        client.Timeout = TimeSpan.FromMinutes(10);
                        break;

                    default:
                        break;
                }
            }).ConfigurePrimaryHttpMessageHandler(messageHandler =>
            {
                var handler = new HttpClientHandler();

                if (handler.SupportsAutomaticDecompression)
                {
                    handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                }

                return handler;
            }).AddPolicyHandler(request => request.Method.Equals(HttpMethod.Get) ? retryPolicy : noOpPolicy);

            var serviceProvider = services.BuildServiceProvider();

            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

            _client = httpClientFactory.CreateClient("KopokopoApiClient");
        }

        /// <summary>
        /// KopokopoClient takes in an instance of HttpClient which can be used in Dependency Injection Container
        /// </summary>
        /// <param name="client">HttpClient Instance</param>
        public KopokopoClient(HttpClient client)
        {
            _client = client;
        }

        public string CreateBlindTransfer(CreateBlindTransferRequest createBlindTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateBlindTransferValidator();
            var results = validator.Validate(createBlindTransferRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(createBlindTransferRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> CreateBlindTransferAsync(CreateBlindTransferRequest createBlindTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateBlindTransferValidator();
            var results = await validator.ValidateAsync(createBlindTransferRequest, cancellationToken);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(createBlindTransferRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string CreateMerchantBankAccount(CreateMerchantBankAccountRequest createMerchantBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateMerchantBankAccountValidator();
            var results = validator.Validate(createMerchantBankAccountRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(createMerchantBankAccountRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> CreateMerchantBankAccountAsync(CreateMerchantBankAccountRequest createMerchantBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateMerchantBankAccountValidator();
            var results = await validator.ValidateAsync(createMerchantBankAccountRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(createMerchantBankAccountRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string CreateMerchantMobileWallet(CreateMerchantMobileWalletRequest createMerchantMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateMerchantMobileWalletValidator();
            var results = validator.Validate(createMerchantMobileWalletRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(createMerchantMobileWalletRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> CreateMerchantMobileWalletAsync(CreateMerchantMobileWalletRequest createMerchantMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateMerchantMobileWalletValidator();
            var results = await validator.ValidateAsync(createMerchantMobileWalletRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(createMerchantMobileWalletRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string CreatePayment(CreatePaymentRequest createPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreatePaymentValidator();
            var results = validator.Validate(createPaymentRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(createPaymentRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> CreatePaymentAsync(CreatePaymentRequest createPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreatePaymentValidator();
            var results = await validator.ValidateAsync(createPaymentRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(createPaymentRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string CreateTargetedTransfer(CreateTargetedTransferRequest createTargetedTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateTargetedTransferValidator();
            var results = validator.Validate(createTargetedTransferRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(createTargetedTransferRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> CreateTargetedTransferAsync(CreateTargetedTransferRequest createTargetedTransferRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new CreateTargetedTransferValidator();
            var results = await validator.ValidateAsync(createTargetedTransferRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(createTargetedTransferRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string CreateWebhookSubscription(WebhookSubscriptionRequest webhookSubscriptionRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new WebhookSubscriptionValidator();
            var results = validator.Validate(webhookSubscriptionRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(webhookSubscriptionRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> CreateWebhookSubscriptionAsync(WebhookSubscriptionRequest webhookSubscriptionRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new WebhookSubscriptionValidator();
            var results = await validator.ValidateAsync(webhookSubscriptionRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(webhookSubscriptionRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public KopokopoAccessTokenResponse GetOAuthToken(KopokopoApplicationAuthorizationRequest kopokopoApplicationAuthorizationRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new ApplicationAuthorizationRequestValidator();
            var results = validator.Validate(kopokopoApplicationAuthorizationRequest);

            return !results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<KopokopoAccessTokenResponse>(kopokopoApplicationAuthorizationRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken).GetAwaiter().GetResult();
        }

        public async Task<KopokopoAccessTokenResponse> GetOAuthTokenAsync(KopokopoApplicationAuthorizationRequest kopokopoApplicationAuthorizationRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new ApplicationAuthorizationRequestValidator();
            var results = await validator.ValidateAsync(kopokopoApplicationAuthorizationRequest);

            return !results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<KopokopoAccessTokenResponse>(kopokopoApplicationAuthorizationRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken);
        }

        public KopokopoTokenInformationResponse GetTokenInformation(string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(accessToken)
                ? KopokopoGetRequestAsync<KopokopoTokenInformationResponse>(accessToken, kopokopoRequestEndpoint, cancellationToken: cancellationToken).GetAwaiter().GetResult()
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Access token is required");
        }

        public async Task<KopokopoTokenInformationResponse> GetTokenInformationAsync(string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(accessToken)
                ? await KopokopoGetRequestAsync<KopokopoTokenInformationResponse>(accessToken, kopokopoRequestEndpoint, cancellationToken: cancellationToken)
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Access token is required");
        }

        public KopokopoTokenIntrospectionResponse GetTokenIntrospection(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new AccessTokenRequestValidator();
            var results = validator.Validate(kopokopoAccessTokenRequest);

            return !results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<KopokopoTokenIntrospectionResponse>(kopokopoAccessTokenRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken).GetAwaiter().GetResult();
        }

        public async Task<KopokopoTokenIntrospectionResponse> GetTokenIntrospectionAsync(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new AccessTokenRequestValidator();
            var results = await validator.ValidateAsync(kopokopoAccessTokenRequest);

            return !results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<KopokopoTokenIntrospectionResponse>(kopokopoAccessTokenRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken);
        }

        public string PayRecipientBankAccount(PayRecipientBankAccountRequest paymentBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientBankAccountValidator();
            var results = validator.Validate(paymentBankAccountRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(paymentBankAccountRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> PayRecipientBankAccountAsync(PayRecipientBankAccountRequest payRecipientBankAccountRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientBankAccountValidator();
            var results = await validator.ValidateAsync(payRecipientBankAccountRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(payRecipientBankAccountRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string PayRecipientExternalTill(PayRecipientExternalTillRequest payRecipientExternalTillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientExternalTillValidator();
            var results = validator.Validate(payRecipientExternalTillRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(payRecipientExternalTillRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> PayRecipientExternalTillAsync(PayRecipientExternalTillRequest payRecipientExternalTillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientExternalTillValidator();
            var results = await validator.ValidateAsync(payRecipientExternalTillRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(payRecipientExternalTillRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string PayRecipientMobileWallet(PayRecipientMobileWalletRequest payRecipientMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientMobileWalletValidator();
            var results = validator.Validate(payRecipientMobileWalletRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(payRecipientMobileWalletRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> PayRecipientMobileWalletAsync(PayRecipientMobileWalletRequest payRecipientMobileWalletRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientMobileWalletValidator();
            var results = await validator.ValidateAsync(payRecipientMobileWalletRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(payRecipientMobileWalletRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string PayRecipientPaybill(PayRecipientPaybillRequest payRecipientPaybillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientPaybillValidator();
            var results = validator.Validate(payRecipientPaybillRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(payRecipientPaybillRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> PayRecipientPaybillAsync(PayRecipientPaybillRequest payRecipientPaybillRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PayRecipientPaybillValidator();
            var results = await validator.ValidateAsync(payRecipientPaybillRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(payRecipientPaybillRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string PollTransactions(PollTransactionRequest pollingRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PollTransactionValidator();
            var results = validator.Validate(pollingRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(pollingRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> PollTransactionsAsync(PollTransactionRequest pollingRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new PollTransactionValidator();
            var results = await validator.ValidateAsync(pollingRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(pollingRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public MpesaPaymentQueryResponse QueryMpesaPayment(MpesaPaymentStatusRequest mpesaPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(mpesaPaymentStatusRequest.Id)
                ? KopokopoGetRequestAsync<MpesaPaymentQueryResponse>(accessToken, kopokopoRequestEndpoint, mpesaPaymentStatusRequest.Id, cancellationToken).GetAwaiter().GetResult()
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Incoming payment id is required");
        }

        public async Task<MpesaPaymentQueryResponse> QueryMpesaPaymentAsync(MpesaPaymentStatusRequest mpesaPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(mpesaPaymentStatusRequest.Id)
                ? await KopokopoGetRequestAsync<MpesaPaymentQueryResponse>(accessToken, kopokopoRequestEndpoint, mpesaPaymentStatusRequest.Id, cancellationToken)
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Incoming payment id is required");
        }

        public PaymentQueryStatusResponse QueryPaymentStatus(CreatePaymentStatusRequest createPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(createPaymentStatusRequest.Id)
                ? KopokopoGetRequestAsync<PaymentQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, createPaymentStatusRequest.Id, cancellationToken).GetAwaiter().GetResult()
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Incoming payment id is required");
        }

        public async Task<PaymentQueryStatusResponse> QueryPaymentStatusAsync(CreatePaymentStatusRequest createPaymentStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(createPaymentStatusRequest.Id)
                ? await KopokopoGetRequestAsync<PaymentQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, createPaymentStatusRequest.Id, cancellationToken)
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Incoming payment id is required");
        }

        public PollTransactionQueryStatusResponse QueryPollTransactionStatus(PollTransactionStatusRequest pollingStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(pollingStatusRequest.Id)
                ? KopokopoGetRequestAsync<PollTransactionQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, pollingStatusRequest.Id, cancellationToken).GetAwaiter().GetResult()
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Polling reference id is required");
        }

        public async Task<PollTransactionQueryStatusResponse> QueryPollTransactionStatusAsync(PollTransactionStatusRequest pollingStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(pollingStatusRequest.Id)
                ? await KopokopoGetRequestAsync<PollTransactionQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, pollingStatusRequest.Id, cancellationToken)
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Polling reference id is required");
        }

        public TransactionNotificationQueryStatusResponse QueryTransactionSMSNotificationStatus(TransactionSMSNotificationQueryStatusRequest transactionSMSNotificationQueryStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(transactionSMSNotificationQueryStatusRequest.Id)
                ? KopokopoGetRequestAsync<TransactionNotificationQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, transactionSMSNotificationQueryStatusRequest.Id, cancellationToken).GetAwaiter().GetResult()
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Transaction notification sms reference id is required");
        }

        public async Task<TransactionNotificationQueryStatusResponse> QueryTransactionSMSNotificationStatusAsync(TransactionSMSNotificationQueryStatusRequest transactionSMSNotificationQueryStatusRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(transactionSMSNotificationQueryStatusRequest.Id)
                ? await KopokopoGetRequestAsync<TransactionNotificationQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, transactionSMSNotificationQueryStatusRequest.Id, cancellationToken)
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Transaction notification sms reference id is required");
        }

        public TransferQueryStatusResponse QueryTransferStatus(SettlementTransferQueryRequest settlementTransferQueryRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(settlementTransferQueryRequest.Id)
                ? KopokopoGetRequestAsync<TransferQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, settlementTransferQueryRequest.Id, cancellationToken).GetAwaiter().GetResult()
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Transfer status reference id is required");
        }

        public async Task<TransferQueryStatusResponse> QueryTransferStatusAsync(SettlementTransferQueryRequest settlementTransferQueryRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            return !string.IsNullOrWhiteSpace(settlementTransferQueryRequest.Id)
                ? await KopokopoGetRequestAsync<TransferQueryStatusResponse>(accessToken, kopokopoRequestEndpoint, settlementTransferQueryRequest.Id, cancellationToken)
                : throw new KopokopoAPIException(HttpStatusCode.BadRequest, "Transfer status reference id is required");
        }

        public string ReceiveMpesaPayment(MpesaPaymentRequest mpesaPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new MpesaPaymentValidator();
            var results = validator.Validate(mpesaPaymentRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(mpesaPaymentRequest, kopokopoRequestEndpoint, accessToken, cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> ReceiveMpesaPaymentAsync(MpesaPaymentRequest mpesaPaymentRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new MpesaPaymentValidator();
            var results = await validator.ValidateAsync(mpesaPaymentRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(mpesaPaymentRequest, kopokopoRequestEndpoint, accessToken, cancellationToken));
        }

        public string RevokeOAuthToken(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new AccessTokenRequestValidator();
            var results = validator.Validate(kopokopoAccessTokenRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(kopokopoAccessTokenRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> RevokeOAuthTokenAsync(KopokopoAccessTokenRequest kopokopoAccessTokenRequest, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new AccessTokenRequestValidator();
            var results = await validator.ValidateAsync(kopokopoAccessTokenRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(kopokopoAccessTokenRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken));
        }

        public string TransactionSMSNotification(TransactionSMSNotificationRequest transactionSMSNotificationRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new TransactionSMSNotificationValidator();
            var results = validator.Validate(transactionSMSNotificationRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : KopokopoPostRequestAsync<object>(transactionSMSNotificationRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken).GetAwaiter().GetResult());
        }

        public async Task<string> TransactionSMSNotificationAsync(TransactionSMSNotificationRequest transactionSMSNotificationRequest, string accessToken, string kopokopoRequestEndpoint, CancellationToken cancellationToken = default)
        {
            var validator = new TransactionSMSNotificationValidator();
            var results = await validator.ValidateAsync(transactionSMSNotificationRequest);

            return (string)(!results.IsValid
                ? throw new KopokopoAPIException(HttpStatusCode.BadRequest, string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage.ToString())))
                : await KopokopoPostRequestAsync<object>(transactionSMSNotificationRequest, kopokopoRequestEndpoint, cancellationToken: cancellationToken));
        }

        private async Task<T> KopokopoGetRequestAsync<T>(string accessToken, string kopokopoEndpoint, string id = null, CancellationToken cancellationToken = default) where T : new()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            T result = new();
            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response;
            if (!string.IsNullOrWhiteSpace(id))
            {
                response = await _client.GetAsync($"{kopokopoEndpoint}{id}", cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = await _client.GetAsync($"{kopokopoEndpoint}", cancellationToken).ConfigureAwait(false);
            }

            if (response.IsSuccessStatusCode)
            {
#if NET5_0_OR_GREATER
                await response.Content.ReadAsStreamAsync(cancellationToken).ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    result = _serializer.Deserialize<T>(json);
                }, cancellationToken);
#endif
#if NETSTANDARD2_0_OR_GREATER
                await response.Content.ReadAsStreamAsync().ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    result = _serializer.Deserialize<T>(json);
                }, cancellationToken);
#endif
            }
            else
            {
                KopokopoErrorResponse kopokopoErrorResponse = new KopokopoErrorResponse();
#if NET5_0_OR_GREATER
                await response.Content.ReadAsStreamAsync(cancellationToken).ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    kopokopoErrorResponse = _serializer.Deserialize<KopokopoErrorResponse>(json);
                }, cancellationToken);
                throw new KopokopoAPIException(new HttpRequestException(kopokopoErrorResponse.ErrorMessage), response.StatusCode, kopokopoErrorResponse);
#endif
#if NETSTANDARD2_0_OR_GREATER
                await response.Content.ReadAsStreamAsync().ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    kopokopoErrorResponse = _serializer.Deserialize<KopokopoErrorResponse>(json);
                }, cancellationToken);
                throw new KopokopoAPIException(new HttpRequestException(kopokopoErrorResponse.ErrorMessage), response.StatusCode, kopokopoErrorResponse);
#endif
            }
            return result;
        }

        private async Task<T> KopokopoPostRequestAsync<T>(object kopokopoDto, string kopokopoEndpoint, string accessToken = null, CancellationToken cancellationToken = default) where T : new()
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            T result = new();
            string json = JsonConvert.SerializeObject(kopokopoDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _client.PostAsync(kopokopoEndpoint, content, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
#if NET5_0_OR_GREATER
                await response.Content.ReadAsStreamAsync(cancellationToken).ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    result = _serializer.Deserialize<T>(json);
                }, cancellationToken);
#endif
#if NETSTANDARD2_0_OR_GREATER
                await response.Content.ReadAsStreamAsync().ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    result = _serializer.Deserialize<T>(json);
                }, cancellationToken);
#endif
            }
            else
            {
                KopokopoErrorResponse kopokopoErrorResponse = new KopokopoErrorResponse();
#if NET5_0_OR_GREATER
                await response.Content.ReadAsStreamAsync(cancellationToken).ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    kopokopoErrorResponse = _serializer.Deserialize<KopokopoErrorResponse>(json);
                }, cancellationToken);
                throw new KopokopoAPIException(new HttpRequestException(kopokopoErrorResponse.ErrorMessage), response.StatusCode, kopokopoErrorResponse);
#endif
#if NETSTANDARD2_0_OR_GREATER
                await response.Content.ReadAsStreamAsync().ContinueWith((Task<Stream> stream) =>
                {
                    using var reader = new StreamReader(stream.Result);
                    using var json = new JsonTextReader(reader);
                    kopokopoErrorResponse = _serializer.Deserialize<KopokopoErrorResponse>(json);
                }, cancellationToken);
                throw new KopokopoAPIException(new HttpRequestException(kopokopoErrorResponse.ErrorMessage), response.StatusCode, kopokopoErrorResponse);
#endif
            }
            return result;
        }
    }
}
