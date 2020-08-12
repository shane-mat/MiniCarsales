using System;
using System.Net;

namespace MiniCarsales.API.Application.Common.Exceptions
{
    public class CustomException: Exception
    {
        public CustomException(HttpStatusCode code, object errors=null)
        {
            Code = code;
            Errors = errors;
        }

        public HttpStatusCode Code { get; set; }
        public object Errors { get; set; }
    }
}