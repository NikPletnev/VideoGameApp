using System.Net;
using System.Text.Json;

namespace VideoGameApp.API.Infrastructure
{
    public class GlobalExeptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExeptionHandler> _logger;

        public GlobalExeptionHandler(RequestDelegate next, ILogger<GlobalExeptionHandler> logger)
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
                _logger.LogError($"Exeption: {ex.Message}");
                await (HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message));
            }
            catch
            {
                await _next(context);
            }


        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code, string message)
        {
            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }
    }
}
