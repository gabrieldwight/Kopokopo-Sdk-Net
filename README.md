# Kopokopo-Sdk-Net
This is a Kopokopo SDK to allow you to integrate Kopokopo API in net framework, .NetCore, NET5, NET6 and Net Standard projects.
[![Build status](https://gabrieldwight.visualstudio.com/KopokopoSdk/_apis/build/status/KopokopoSdk-CI)](https://gabrieldwight.visualstudio.com/KopokopoSdk/_build/latest?definitionId=8)
[![NuGet version (KopokopoSdk)](https://img.shields.io/nuget/v/KopokopoSdk.svg?style=flat-square)](https://www.nuget.org/packages/KopokopoSdk/)

A .NET Standard Kopokopo API Helper Library for .NET Developers.
- [End User License](https://github.com/gabrieldwight/Kopokopo-Sdk-Net/blob/master/LICENSE)
- [NuGet Package](https://www.nuget.org/packages/KopokopoSdk/)
- [Kopokopo API Docs](https://api-docs.kopokopo.com/)

## Supported Platforms

|   *Platform*   | .Net 6.0 | .Net 5.0 | .NET Core | .NET Framework | Mono | Xamarin.iOS | Xamarin.Android | Xamarin.Mac |     UWP    |
|:--------------:|---------:|---------:|:---------:|:--------------:|:----:|:-----------:|:---------------:|:-----------:|:----------:|
| *Min. Version* |    6     |    5     |    2.0    |      4.6.1     |  5.4 |    10.14    |       8.0       |     3.8     | 10.0.16299 |

## Capabilities

> Note: **This package is WIP**. The capabilities of Kopokopo API will be reflected soon. Feel free to contribute!

- [ ] Core functions
  - [x] Create Webhook subscription
  - [ ] Validating webhook subscription
  - [x] Receive Mpesa Payment Via Stkpush
  - [x] Query incoming payments
  - [x] Pay Recipients
  - [x] Create payment
  - [x] Query payment status
  - [x] Polling
  - [x] Transfer Accounts
  - [x] Transaction SMS Notifications
- [x] Receiving Message (via Webhook)
  - [x] Buy Goods Transaction Received
  - [x] B2B Transaction Received
  - [x] Merchant to merchant Transaction Received
  - [x] Buy Goods Transaction Reversed
  - [x] Settlement Transfer Completed
  - [x] Customer Created

## Installation
- PackageManager: ```PM> Install-Package KopokopoSdk```
- DotNetCLI: ```> dotnet add package KopokopoSdk```

## Setting yourself for successful mpesa integration
Before you proceed kindly aquaint yourself with Mpesa Apis by going through the Docs in Safaricom's developer portal or Daraja if you like.

1.  Obtain consumerKey, consumerSecret and Passkey (for Lipa Na Mpesa Online APIs) from daraja portal.

2.  Ensure your project is running on the minimun supported versions of .Net 

3.  KopokopoSdk is dependency injection (DI) friendly and can be readily injected into your classes. You can read more on DI in Asp.Net core [**here**](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0). If you can't use DI you can always manually create a new instance of KopokopoClient and pass in an httpClient instance in it's constructor. eg.

```c#
// When Dependency Injection is not possible...

//create httpclient instance
var httpClient = new HttpClient();

httpClient.BaseAddress = KopokopoRequestEndPoint.SandboxBaseAddress; //Use MpesaRequestEndPoint.LiveBaseAddress in production
	
//create Kopokopo API client instance
var kopokopoClient = new KopokopoClient(httpClient); //make sure to pass httpclient intance as an argument
	
```
I would recommend creating KopokopoClient using Dependency Injection. [Optional] You can use any IOC container or Microsoft DI container in your legacy projects.
```c#
// Adding Dependency Injection into legacy projects

public static IServiceProvider ServiceProvider;


// To be used in the main application startup method
void Application_Start(object sender, EventArgs e)
{
  var hostBuilder = new HostBuilder();
  hostBuilder.ConfigureServices(ConfigureServices);
  var host = hostBuilder.Build();

  ServiceProvider = host.Services;
}

void ConfigureServices(IServiceCollection services)
{
   services.AddHttpClient<IKopokopoClient, KopokopoClient>(options => options.BaseAddress = KopokopoRequestEndPoint.SandboxBaseAddress);
   //inject services here
}
	
```

## Registering KopokopoClient & Set the BaseAddress -Dependency Injection Method in ASPNETCORE
* Install KopokopoSdk Project via Nuget Package Manager Console or Nuget Package Manager GUI.

## For ASPNETCORE projects
* In **Startup.cs** add the namespace...

```c#    
using KopokopoSdk;
```

* Inside ConfigureServices method add the following

```c#
services.Configure<KopokopoApiConfiguration>(options =>
            {
                Configuration.GetSection("KopokopoApiConfiguration").Bind(options);
            });
services.AddHttpClient<IKopokopoClient, KopokopoClient>(options => options.BaseAddress = KopokopoRequestEndPoint.SandboxBaseAddress);
```

## OR using KopokopoSDK Extension
```c#    
using KopokopoSdk.Extensions;
```

* Inside ConfigureServices method add the following

```c#
services.Configure<KopokopoApiConfiguration>(options =>
            {
                Configuration.GetSection("KopokopoApiConfiguration").Bind(options);
            });
services.AddKopokopoService(Enums.Environment.Sandbox);
```


Use ```KopokopoRequestEndPoint.LiveBaseAddress``` as base address/base url in production. You can do an environment check using the IHostingEnvironment property in asp.net core.

* Once the KopokopoClient is registered, you can pass it and use it in your classes to make API calls to Kopokopo Server as follows;
```c#
using KopokopoSdk; //Add KopokopoSdk namespace
public class PaymentsController
{
	private readonly IKopokopoClient _kopokopoClient;
	public PaymentsController(IKopokopoCleint kopokopoClient)
	{
		_kopokopoClient = kopokopoClient;
	}
	....
	//code omitted for brevity
}
```

## Requesting for the Accesstoken
kopokopo APIs require authorization to use the APIs. The accesstoken (auth token) has to be used with each api call. The accesstoken expire after an hour so it is recommended that you use a caching strategy to refresh the token after every hour or less depending on how  much traffic your site has.

* To get an accesstoken, invoke the ``` kopokopoClient..GetOAuthTokenAsync(*args); ``` method. You have to await the Async call. use Non-Async method call provided if you cannot leverage async.

```c# 
//Async Method
KopokopoApplicationAuthorizationRequest kopokopoApplicationAuthorizationRequest = new KopokopoApplicationAuthorizationRequest();
kopokopoApplicationAuthorizationRequest.ClientId = _kopokopoApiConfiguration.ClientId;
kopokopoApplicationAuthorizationRequest.ClientSecret = _kopokopoApiConfiguration.ClientSecret;
var accesstoken = await _kopokopoClient..GetOAuthTokenAsync(kopokopoApplicationAuthorizationRequest, KopokopoRequestEndpoint.OAuthToken);

```

Note that you have to pass in a ClientId, ClientSecret provided by Mpesa.

## Create Webhook subscription Request
```c#
WebhookSubscriptionRequest webhookSubscriptionRequest = new WebhookSubscriptionRequest();
webhookSubscriptionRequest.EventType = "event_type";
webhookSubscriptionRequest.Url = "callback_url";
webhookSubscriptionRequest.Scope = "scope"; // till or company
webhookSubscriptionRequest.ScopeReference = "reference"; // till number 

var results = await _kopokopoClient.CreateWebhookSubscriptionAsync(webhookSubscriptionRequest, await RetrieveAccessToken(), KopokopoRequestEndpoint.CreateWebHookSubscription);
```

## Validating webhook
```c#
Request.Headers.TryGetValue("X-KopoKopo-Signature", out StringValues kopokopoSignature);

if (WebhookSignatureUtil.ValidateKopokopoSignature(RequestBody, _kopokopoApiConfiguration.ApiKey, kopokopoSignature))
{
    return Ok();
}
else
{
    return BadRequest();
}
```

## Mpesa Payments STKPush
```c#
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
```

## Error handling
KopokopoClient Throws ```KopokopoApiException``` whenever A 200 status code is not returned. It is your role as the developer to catch
the exception and continue processing in your aplication. Snippet below shows how you can catch the KopokopoApiException.

```c#
using KopokopoSdk.Exceptions; // add this to you class or namespace


try
{	
	return await _kopokopoClient.ReceiveMpesaPaymentAsync(mpesaPaymentRequest, await RetrieveAccessToken(), KopokopoRequestEndpoint.ReceiveMpesaPaymentsViaStk);
}
catch (KopokopoApiException e)
{
	_logger.LogError(ex, ex.Message);
}
			
```
