using System;
using System.Net;

namespace MicroService.Common.Core.Web.Exceptions
{
    public class NoneSuccessFullStatusCodeException : Exception
    {
        public NoneSuccessFullStatusCodeException(HttpStatusCode statusCode, string message) : base(
            $"Statuscode: {statusCode}, message: {message}")
        {
        }
    }
}