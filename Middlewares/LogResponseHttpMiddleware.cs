using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace ApiAuthor.Middlewares
{
    public class LogResponseHttpMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger<LogResponseHttpMiddleware> Logger;

        public LogResponseHttpMiddleware(RequestDelegate next, ILogger<LogResponseHttpMiddleware> logger)
        {
            Next = next;
            Logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Stream bodyResponseOriginal = context.Response.Body;
                context.Response.Body = ms;

                await Next(context);

                ms.Seek(0, SeekOrigin.Begin);
                string response = new StreamReader(ms).ReadToEnd();
                ms.Seek(0, SeekOrigin.Begin);

                await ms.CopyToAsync(bodyResponseOriginal);
                context.Response.Body = bodyResponseOriginal;
                Logger.LogInformation(response);
            }
        }
    }
}
