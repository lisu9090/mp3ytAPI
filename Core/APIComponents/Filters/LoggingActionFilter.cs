using APIComponents.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace APIComponents.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LoggingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            BaseController bController = (BaseController)context.Controller;
            //check for error and log propper msg
            bController.Logger.Log(LogLevel.Information, "", new object[0]);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            BaseController bController = (BaseController)context.Controller;
            bController.Logger.Log(LogLevel.Information, "", new object[0]);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return new TaskFactory().StartNew((contextInput) => {
                OnActionExecuting((ActionExecutingContext)contextInput);
            }, context);
        }
    }
}
