using System.Text.Json.Serialization;

namespace KopokopoSdk.Responses
{
    public class KopokopoErrorResponse
    {
        [JsonPropertyName("error_code")]
        public long ErrorCode { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
    }
}
