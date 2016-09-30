using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookStack
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action="index", id = RouteParameter.Optional }
            );
        }
    }
}
