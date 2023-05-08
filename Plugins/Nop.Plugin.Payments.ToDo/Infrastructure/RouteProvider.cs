﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Payments.ToDo.Infrastructure
{

    public class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute(ToDoDefaults.PickRouteName,
                "Plugins/Mangos/pick",
                new { controller = "Mangos", action = "pick" });
        }



        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;
    }

}
