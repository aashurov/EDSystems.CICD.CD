using EDSystems.Application.Common.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace EDSystems.WebApi.Middleware
{
    /// <summary>
    ///
    /// </summary>
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///
        /// </summary>
        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        ///
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }
            return context.Response.WriteAsync(result);
        }
    }
}