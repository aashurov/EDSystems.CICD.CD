namespace EDSystems.WebApi.Middleware
{
    /// <summary>
    ///
    /// </summary>
    public static class CustomExceptionHandlerMiddlewareExstentions
    {
        /// <summary>
        ///
        /// </summary>
        public static IApplicationBuilder UseCustomeExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}