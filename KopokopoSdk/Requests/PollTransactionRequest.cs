using Newtonsoft.Json;
using System;

namespace KopokopoSdk.Requests
{
    public class PollTransactionRequest : KopokopoBaseRequest
    {
        /// <summary>
        /// The scope of the polling request. Could be either company or till
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// If the scope is till the scope reference is required and it should be your till number
        /// </summary>
        [JsonProperty("scope_reference")]
        public string ScopeReference { get; set; }

        /// <summary>
        /// A string containing a date in the iso8601 format
        /// </summary>
        [JsonProperty("from_time")]
        public DateTimeOffset FromTime { get; set; }

        /// <summary>
        /// A string containing a date in the iso8601 format
        /// </summary>
        [JsonProperty("to_time")]
        public DateTimeOffset ToTime { get; set; }
    }
}
