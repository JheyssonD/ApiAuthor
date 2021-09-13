using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ApiAuthor.Filters
{
    public class MyActionFilter : IActionFilter
    {
        public readonly ILogger<MyActionFilter> Logger;

        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            Logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("antes de ejecutar la accion");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("despues de ejecutar la accion");
        }
    }
}
