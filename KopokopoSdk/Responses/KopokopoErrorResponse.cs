﻿using Newtonsoft.Json;

namespace KopokopoSdk.Responses
{
    public class KopokopoErrorResponse
    {
        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
