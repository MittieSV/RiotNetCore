using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RiotNetCore.RequestGuard
{
    public class RiotNetCoreRequestException : Exception
    {
        public RiotNetCoreRequestException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public RiotNetCoreRequestException(string message, HttpStatusCode httpStatusCode, Exception inner) : base(message, inner)
        {
            HttpStatusCode = httpStatusCode;
        }

        public HttpStatusCode HttpStatusCode { get; private set; }
    }
}
