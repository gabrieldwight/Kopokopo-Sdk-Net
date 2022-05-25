using KopokopoSdk.Exceptions;
using KopokopoSdk.Interfaces;
using KopokopoSdk.Requests;
using KopokopoSdk.Web.Models;
using KopokopoSdk.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace KopokopoSdk.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly KopokopoApiConfiguration _kopokopoApiConfiguration;
        private readonly IKopokopoClient _kopokopoClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOptions<KopokopoApiConfiguration> kopokopoApiConfiguration, IKopokopoClient kopokopoClient, 
            IMemoryCache memoryCache, ILogger<HomeController> logger)
        {
            _kopokopoApiConfiguration = kopokopoApiConfiguration.Value;
            _kopokopoClient = kopokopoClient;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult WebhookSubscription()
        {
            WebSubcriptionViewModel webSubcriptionViewModel = new WebSubcriptionViewModel();
            webSubcriptionViewModel.WebhookEventType = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Buy Goods Transaction Received", Value = SubscriptionEventType.BuyGoodsTransactionReceived },
                new SelectListItem() { Text = "Buy Goods Transaction Reversed",  Value = SubscriptionEventType.BuyGoodsTransactionReversed },
                new SelectListItem() { Text = "B2B Transaction Received", Value = SubscriptionEventType.B2BTransactionReceived },
                new SelectListItem() { Text = "M2M Transaction Received", Value = SubscriptionEventType.M2MTransactionReceived },
                new SelectListItem() { Text = "Settlement Transfer Completed", Value = SubscriptionEventType.SettlementTransferCompleted },
                new SelectListItem() { Text = "Customer Created", Value = SubscriptionEventType.CustomerCreated }
            };

            webSubcriptionViewModel.WebhookScope = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Company", Value = SubscriptionScope.ScopeCompany },
                new SelectListItem() { Text = "TIll", Value = SubscriptionScope.ScopeTill}
            };

            return View(webSubcriptionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WebhookSubscription(WebSubcriptionViewModel webSubcriptionViewModel)
        {
            try
            {
                WebhookSubscriptionRequest webhookSubscriptionRequest = new WebhookSubscriptionRequest();
                webhookSubscriptionRequest.EventType = webSubcriptionViewModel.SelectedEventType;
                webhookSubscriptionRequest.Url = webSubcriptionViewModel.WebhookUrl;
                webhookSubscriptionRequest.Scope = webSubcriptionViewModel.SelectedScope;
                webhookSubscriptionRequest.ScopeReference = webSubcriptionViewModel.WebhookScopeReference;

                var results = await _kopokopoClient.CreateWebhookSubscriptionAsync(webhookSubscriptionRequest, await RetrieveAccessToken(), KopokopoRequestEndpoint.CreateWebHookSubscription);

                return RedirectToAction(nameof(Index));
            }
            catch (KopokopoAPIException ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return RedirectToAction(nameof(WebhookSubscription));
        }

        public IActionResult MpesaPayment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MpesaPayment(StkPushViewModel stkPushViewModel)
        {
            try
            {
                MpesaPaymentRequest mpesaPaymentRequest = new MpesaPaymentRequest();
                mpesaPaymentRequest.PaymentChannel = stkPushViewModel.PaymentChannel;
                mpesaPaymentRequest.TillNumber = stkPushViewModel.TillNumber;
                mpesaPaymentRequest.Subscriber = new Subscriber();
                mpesaPaymentRequest.Subscriber.FirstName = stkPushViewModel.FirstName;
                mpesaPaymentRequest.Subscriber.LastName = stkPushViewModel.LastName;
                mpesaPaymentRequest.Subscriber.PhoneNumber = stkPushViewModel.PhoneNumber;
                mpesaPaymentRequest.Subscriber.Email = stkPushViewModel.Email;
                mpesaPaymentRequest.Amount = new MpesaPaymentAmount();
                mpesaPaymentRequest.Amount.Currency = stkPushViewModel.Currency;
                mpesaPaymentRequest.Amount.Value = stkPushViewModel.Amount;
                mpesaPaymentRequest.Links = new Links();
                mpesaPaymentRequest.Links.CallbackUrl = stkPushViewModel.CallbackUrl;

                var results = await _kopokopoClient.ReceiveMpesaPaymentAsync(mpesaPaymentRequest, await RetrieveAccessToken(), KopokopoRequestEndpoint.ReceiveMpesaPaymentsViaStk);

                return RedirectToAction(nameof(Index));
            }
            catch (KopokopoAPIException ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<string> RetrieveAccessToken()
        {
            var cacheKey = "KopokopoAccessToken";

            if (_memoryCache.TryGetValue(cacheKey, out string kopokopoAccessToken))
            {
                _logger.LogInformation("Getting token from memory...");
                return kopokopoAccessToken;
            }
            else
            {
                _logger.LogInformation("Getting token from Mpesa Server...");
                KopokopoApplicationAuthorizationRequest kopokopoApplicationAuthorizationRequest = new KopokopoApplicationAuthorizationRequest();
                kopokopoApplicationAuthorizationRequest.ClientId = _kopokopoApiConfiguration.ClientId;
                kopokopoApplicationAuthorizationRequest.ClientSecret = _kopokopoApiConfiguration.ClientSecret;

                var results = await _kopokopoClient.GetOAuthTokenAsync(kopokopoApplicationAuthorizationRequest, KopokopoRequestEndpoint.OAuthToken);
                kopokopoAccessToken = results.AccessToken;

                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(59));

                // Save data in cache
                _memoryCache.Set(cacheKey, kopokopoAccessToken, cacheEntryOptions);

                return kopokopoAccessToken;
            }
        }
    }
}