namespace Questar.OneRoster.ApiFramework
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class OneRosterApiFrameworkMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly OneRosterApiFrameworkOptions _options;

        public OneRosterApiFrameworkMiddleware(RequestDelegate next, OneRosterApiFrameworkOptions options)
        {
            _next = next;
            _options = options;
        }

        public Task Invoke(HttpContext httpContext) => _next(httpContext);
    }
}