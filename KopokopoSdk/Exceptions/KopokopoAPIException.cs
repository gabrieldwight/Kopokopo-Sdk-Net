using KopokopoSdk.Responses;
using System;
using System.Net;

namespace KopokopoSdk.Exceptions
{
    /// <summary>
    /// Kopokopo Api Exception Custom class
    /// </summary>
    public class KopokopoAPIException : Exception
    {
        /// <summary>
        /// Http Status code retrieved from the Kopokopo API call
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        public KopokopoErrorResponse KopokopoErrorResponse { get; set; }

        public KopokopoAPIException()
        {

        }

        public KopokopoAPIException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            StatusCode = httpStatusCode;
        }

        public KopokopoAPIException(Exception ex, HttpStatusCode statusCode, KopokopoErrorResponse kopokopoErrorResponse) : base(ex.Message)
        {
            StatusCode = statusCode;
            KopokopoErrorResponse = kopokopoErrorResponse;
        }
    }
}
