using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET_MVC_SimpleApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin Route",
                url: "AdminPanel/{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = @"^Admin.*$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //This is not before the default one, in order for it not to be visible when redirecting to homepage
            routes.MapRoute(
                name: "Secret Route",
                url: "very/super/cool/secret/route/{color}",
                defaults: new { controller = "Home", action = "Index", color = UrlParameter.Optional }
            );
        }
    }
}
