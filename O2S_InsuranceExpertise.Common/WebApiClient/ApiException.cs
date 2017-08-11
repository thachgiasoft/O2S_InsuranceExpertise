using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace O2S_InsuranceExpertise.Common.WebApiClient
{
    /// <summary>
    /// Exception khi goi API
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Ma HttpCode khi goi API
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        public ApiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
