using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Photography.Infrastructure.Types.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photography.Constraints
{
    public partial class PageConstraint : IRouteConstraint
    {
        public virtual bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.UrlGeneration)
            {
                return true;
            }

            var slug = values["slug"] != null ? values["slug"].ToString() : null;

            if (string.IsNullOrWhiteSpace(slug))
            {
                // Homepage
                return true;
            }

            // Get category service
            var categoryService = httpContext.RequestServices.GetRequiredService<ICategoryService>();

            var category = categoryService.GetBySlug(slug);

            if (category == null)
            {
                return false;
            }

            values["category"] = category;
            return true;
        }
    }
}
