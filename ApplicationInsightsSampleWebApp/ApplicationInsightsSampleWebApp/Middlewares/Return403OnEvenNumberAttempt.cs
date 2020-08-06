namespace ApplicationInsightsSampleWebApp.Middlewares
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    public class Return403OnEvenNumberAttempt
    {
        private readonly RequestDelegate _next;
        private int i = 0;

        public Return403OnEvenNumberAttempt(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext httpContext)
        {
            if (i++ % 2 == 0)
            {
                var response = httpContext.Response;
                response.StatusCode = 403;
                return response.WriteAsync(string.Empty);
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Return403OnEvenNumberAttemptMiddlewareExtensions
    {
        public static IApplicationBuilder UseAlwaysReturn403Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Return403OnEvenNumberAttempt>();
        }
    }
}

