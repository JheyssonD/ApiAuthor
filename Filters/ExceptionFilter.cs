using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ApiAuthor.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute
    {
        public readonly ILogger<ExceptionFilter> Logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            Logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            Logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }
    }
}
