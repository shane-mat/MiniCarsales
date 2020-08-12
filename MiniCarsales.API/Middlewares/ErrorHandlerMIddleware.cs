using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using MiniCarsales.API.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiniCarsales.API.Middlewares 
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlerMiddleware> logger)
        {
            object errors = null;

            switch(ex)
            {
                case CustomException cux:
                    logger.LogError(ex, "API Error");
                    errors = cux.Errors;
                    context.Response.StatusCode = (int)cux.Code;
                    break;
                default:
                    logger.LogError(ex, "Server Error");
                    errors = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            if(errors != null)
            {
                var result = JsonSerializer.Serialize(new {errors});
                await context.Response.WriteAsync(result);
            }
        }
    }
}