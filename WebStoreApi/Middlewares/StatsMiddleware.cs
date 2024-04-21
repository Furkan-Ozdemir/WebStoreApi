namespace WebStoreApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class StatsMiddleware
    {
        private readonly RequestDelegate _next;

        public StatsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("once");
            var result = _next(httpContext);
            Console.WriteLine("sonra");

            return result;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class StatsMiddlewareExtensions
    {
        public static IApplicationBuilder UseStatsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatsMiddleware>();
        }
    }
}
