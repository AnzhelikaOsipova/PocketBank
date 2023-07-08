using Newtonsoft.Json;
using System.Net;

namespace PocketBank.User.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) 
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
                _logger.LogError(ex, ex.Message);
                switch(ex)
                {
                    default:
                        await WriteResponseAsync(ex, context, HttpStatusCode.InternalServerError);
                        break;
                }
            }
        }

        private async Task WriteResponseAsync<T>(T exception, HttpContext context, HttpStatusCode statusCode) where T : Exception
        {
            var response = context.Response;

            response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(exception);

            await context.Response.WriteAsync(result);
        }
    }
}
