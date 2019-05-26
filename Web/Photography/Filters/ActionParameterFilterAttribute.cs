using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photography.Filters
{
    public class ActionParameterFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // This filter passes all route values as parameters in the action response.

            var c = filterContext.Controller as Controller;

            foreach (var value in c.RouteData.Values)
            {
                filterContext.ActionArguments[value.Key] = value.Value;
            }
        }
    }
}
