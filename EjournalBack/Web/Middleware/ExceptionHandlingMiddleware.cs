using EjournalBack.Web.Models.Responses;
using Microsoft.Extensions.Options;
using System.Net;

namespace EjournalBack.Web.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unexpected error occurred.");     

            ExceptionResponse response = exception switch
            {
                OperationCanceledException _ => new ExceptionResponse(System.Net.HttpStatusCode.GatewayTimeout,
                    "The time to complete the request has been exceeded."),
                //Exception _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
                Exception _ => new ExceptionResponse(HttpStatusCode.InternalServerError, $"{exception.Message}")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}