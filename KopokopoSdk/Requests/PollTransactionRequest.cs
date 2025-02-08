using System;
using System.Text.Json.Serialization;

namespace KopokopoSdk.Requests
{
    public class PollTransactionRequest : KopokopoBaseRequest
    {
        /// <summary>
        /// The scope of the polling request. Could be either company or till
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// If the scope is till the scope reference is required and it should be your till number
        /// </summary>
        [JsonPropertyName("scope_reference")]
        public string ScopeReference { get; set; }

        /// <summary>
        /// A string containing a date in the iso8601 format
        /// </summary>
        [JsonPropertyName("from_time")]
        public DateTimeOffset FromTime { get; set; }

        /// <summary>
        /// A string containing a date in the iso8601 format
        /// </summary>
        [JsonPropertyName("to_time")]
        public DateTimeOffset ToTime { get; set; }
    }
}
