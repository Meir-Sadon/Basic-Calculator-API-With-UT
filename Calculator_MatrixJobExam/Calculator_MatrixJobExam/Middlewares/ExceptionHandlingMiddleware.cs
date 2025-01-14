namespace Calculator_MatrixJobExam.Middlewares
{
    /// <summary>
    /// Middleware for handling exceptions globally.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
    /// </remarks>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger instance.</param>
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        /// <summary>
        /// Invokes the middleware to handle the HTTP request.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>A task that represents the completion of request processing.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new
            {
                error = "An unexpected error occurred.",
                details = exception.Message
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
