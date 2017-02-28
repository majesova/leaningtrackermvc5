using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace LearningTracker.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine("Ejecutando controller", actionExecutedContext.ActionContext.ActionDescriptor);
        }
    }
}