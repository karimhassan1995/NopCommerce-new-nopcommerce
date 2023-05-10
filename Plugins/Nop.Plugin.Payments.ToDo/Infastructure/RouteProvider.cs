using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;
using Nop.Web.Infrastructure;

namespace Nop.Plugin.Payments.ToDo.Infrastructure
{

    public class RouteProvider : BaseRouteProvider, IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            var lang = GetLanguageRoutePattern();
            endpointRouteBuilder.MapControllerRoute(name: "Pick",
               pattern: $"{lang}/Pick",
               defaults: new { controller = "Mangos", action = "Pick" });

                endpointRouteBuilder.MapControllerRoute(name: "Index",
             pattern: $"{lang}/ToDoes",
             defaults: new { controller = "ToDoes", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "Index",
              pattern: $"{lang}/Books",
              defaults: new { controller = "Books", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "Create",
              pattern: $"{lang}/Create",
              defaults: new { controller = "ToDoes", action = "Create" });

        
        }



        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 1;
    }

}