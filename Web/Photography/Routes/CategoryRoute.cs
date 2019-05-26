using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Photography.Constraints;
using Photography.Infrastructure.Types.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace Photography.Routes
{
    public class CategoryRoute : Route
    {
        protected readonly IRouteBuilder _builder;
        private TemplateMatcher _matcher;

        public CategoryRoute(IRouteBuilder builder)
            : base(builder.DefaultHandler, "Category", "{*slug}", new RouteValueDictionary { { "controller", "Category" }, { "action", "Listing" } }, new Dictionary<string, object> { { "slug", new PageConstraint() } }, new RouteValueDictionary(), CreateInlineConstraintResolver(builder.ServiceProvider))
        {
            _builder = builder;
        }

        public override Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path;

            EnsureMatcher();

            if (!_matcher.TryMatch(requestPath, context.RouteData.Values))
            {
                // If we got back a null value set, that means the URI did not match
                return Task.CompletedTask;
            }

            // We now have the RouteData, so we can see if the category exists.
            var slug = context.RouteData.Values["slug"] != null ? context.RouteData.Values["slug"].ToString() : null;

            // Get category service
            var categoryService = context.HttpContext.RequestServices.GetRequiredService<ICategoryService>();

            var category = categoryService.GetBySlug(slug);

            if (category != null)
            {
                // Found the category, so set it as a routeData.
                context.RouteData.Values["category"] = category;
            }           

            return base.RouteAsync(context);            
        }


        protected override Task OnRouteMatched(RouteContext context)
        {
            return base.OnRouteMatched(context);
        }

        protected override VirtualPathData OnVirtualPathGenerated(VirtualPathContext context)
        {
            return base.OnVirtualPathGenerated(context);
        }

        protected static IInlineConstraintResolver CreateInlineConstraintResolver(IServiceProvider serviceProvider)
        {
            var inlineConstraintResolver = serviceProvider
                .GetRequiredService<IInlineConstraintResolver>();

            var parameterPolicyFactory = serviceProvider
                .GetRequiredService<ParameterPolicyFactory>();

            // This inline constraint resolver will return a null constraint for non-IRouteConstraint
            // parameter policies so Route does not error
            return new BackCompatInlineConstraintResolver(inlineConstraintResolver, parameterPolicyFactory);
        }

        protected class BackCompatInlineConstraintResolver : IInlineConstraintResolver
        {
            private readonly IInlineConstraintResolver _inner;
            private readonly ParameterPolicyFactory _parameterPolicyFactory;

            public BackCompatInlineConstraintResolver(IInlineConstraintResolver inner, ParameterPolicyFactory parameterPolicyFactory)
            {
                _inner = inner;
                _parameterPolicyFactory = parameterPolicyFactory;
            }

            public IRouteConstraint ResolveConstraint(string inlineConstraint)
            {
                var routeConstraint = _inner.ResolveConstraint(inlineConstraint);
                if (routeConstraint != null)
                {
                    return routeConstraint;
                }

                var parameterPolicy = _parameterPolicyFactory.Create(null, inlineConstraint);
                if (parameterPolicy != null)
                {
                    // Logic inside Route will skip adding NullRouteConstraint
                    return null;
                }

                return null;
            }
        }

        private void EnsureMatcher()
        {
            if (_matcher == null)
            {
                _matcher = new TemplateMatcher(ParsedTemplate, Defaults);
            }
        }        

    }

    public static class MapRouteRouteBuilderExtensions
    {
        public static IRouteBuilder MapCategoryRoute(
     this IRouteBuilder routeBuilder)
        {
            routeBuilder.Routes.Add(new CategoryRoute(routeBuilder));

            return routeBuilder;
        }
    }

    internal static class TreeRouterLoggerExtensions
    {
        private static readonly Action<ILogger, string, string, Exception> _requestMatchedRoute;

        static TreeRouterLoggerExtensions()
        {
            _requestMatchedRoute = LoggerMessage.Define<string, string>(
                LogLevel.Debug,
                new EventId(1, "RequestMatchedRoute"),
                "Request successfully matched the route with name '{RouteName}' and template '{RouteTemplate}'");
        }

        public static void RequestMatchedRoute(
            this ILogger logger,
            string routeName,
            string routeTemplate)
        {
            _requestMatchedRoute(logger, routeName, routeTemplate, null);
        }
    }
}
