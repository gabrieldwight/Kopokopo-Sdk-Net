using System;
using System.Security.Cryptography;
using System.Text;

namespace KopokopoSdk.Util
{
    public static class WebhookSignatureUtil
    {
        public static bool ValidateKopokopoSignature(string requestBodyPayload, string apiKey, string webhookSignature)
        {
            if (string.IsNullOrWhiteSpace(webhookSignature))
            {
                throw new ArgumentNullException(nameof(webhookSignature));
            }
            else
            {
                // Validating signature
                var keyBytes = Encoding.ASCII.GetBytes(apiKey);
                var payLoadDataBytes = Encoding.ASCII.GetBytes(requestBodyPayload);

                using var hmac = new HMACSHA256(keyBytes);
                var hmacBytes = hmac.ComputeHash(payLoadDataBytes);

                var createSignature = BitConverter.ToString(hmacBytes).Replace("-", "").ToLower();

                if (webhookSignature.Equals(createSignature))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
