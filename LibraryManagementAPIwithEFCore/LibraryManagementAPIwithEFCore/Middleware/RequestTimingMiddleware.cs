using System.Diagnostics;

namespace LibraryManagementAPIwithEFCore.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {           
            var stopwatch = Stopwatch.StartNew();
            try
            {                
                await _next(context);
            }
            finally
            {                
                stopwatch.Stop();
                _logger.LogInformation("{Method} {Path} | {StatusCode} | {Elapsed} ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
