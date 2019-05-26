using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Photography.Infrastructure.Types.Category;
using Photography.Infrastructure.Types.Category.Data;

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

            var category = values["category"] != null ? (CategoryEntity)values["category"] : null;

            if (category == null)
            {
                return false;
            }

            return true;
        }
    }
}
