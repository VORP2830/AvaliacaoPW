using AvaliacaoPW.Domain.Exceptions;
using System.Text.Json;

namespace AvaliacaoPW.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
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
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var statusCode = exception is AvaliacaoPWException ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;
            var message = exception is AvaliacaoPWException AvaliacaoPWException ? AvaliacaoPWException.Message : "Ocorreu um erro no sistema!";
            response.StatusCode = statusCode;
            var errorResponse = new
            {
                Message = message,
                ExceptionMessage = exception.Message
            };
            var result = JsonSerializer.Serialize(errorResponse);
            await response.WriteAsync(result);
        }
    }
}