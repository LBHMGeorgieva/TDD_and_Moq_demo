using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Calculator_example___TDD_and_Moq
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "calculator" }
            );
        }
    }
}
