using KopokopoSdk.Util;
using KopokopoSdk.Web.Models;
using KopokopoSdk.Webhooks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Text.Json;

namespace KopokopoSdk.Web.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class BuyGoodsTransactionWebhookController : ControllerBase
    {
        private readonly KopokopoApiConfiguration _kopokopoApiConfiguration;

        public BuyGoodsTransactionWebhookController(IOptions<KopokopoApiConfiguration> kopokopoApiConfiguration)
        {
            _kopokopoApiConfiguration = kopokopoApiConfiguration.Value;
        }

        [HttpPost("buy-goods-tracker")]
        public async Task<IActionResult> BuyGoodsTransactionTracker([FromBody] BuyGoodsTransactionReceive buyGoodsTransaction)
        {
            Request.Headers.TryGetValue("X-KopoKopo-Signature", out StringValues kopokopoSignature);

            if (WebhookSignatureUtil.ValidateKopokopoSignature(JsonSerializer.Serialize(buyGoodsTransaction), _kopokopoApiConfiguration.ApiKey, kopokopoSignature))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
