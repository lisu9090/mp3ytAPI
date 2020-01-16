using APIComponents.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

namespace APIComponents.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LoggingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            BaseController bController = (BaseController)context.Controller;

            var method = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;
            var status = context.HttpContext.Response.StatusCode;
            var exception = context.Exception;

            if(exception != null)
            {
                if(context.ExceptionHandled)
                {
                    bController.Logger.LogWarning(exception, "{method}:{path} -> {status}: Handled exception has occurred. ", method, path, status);
                }
                else
                {
                    bController.Logger.LogError(exception, "{method}:{path} -> {status}: Unhandled exception has occurred! ", method, path, status);
                }
            }
            else
            {
                bController.Logger.LogInformation("{method}:{path} -> {status}: OK", method, path, status);
            }
        }

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    BaseController bController = (BaseController)context.Controller;

        //    var path = context.HttpContext.Request.Path;
        //    var method = context.HttpContext.Request.Method;

        //    bController.Logger.LogInformation("{method}:{path}", method, path);
        //}

        //public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    return new TaskFactory().StartNew((contextInput) => {
        //        OnActionExecuting((ActionExecutingContext)contextInput);
        //    }, context);
        //}
    }
}
