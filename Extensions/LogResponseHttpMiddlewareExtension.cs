using ApiAuthor.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ApiAuthor.Extensions
{
    public static class LogResponseHttpMiddlewareExtension
    {

        public static IApplicationBuilder UseLogResponseHttp(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogResponseHttpMiddleware>();
        }
    }
}
