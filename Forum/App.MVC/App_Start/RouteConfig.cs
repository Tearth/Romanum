using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.MVC.App_Start
{
    class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "View/{categoryAlias}",
                defaults: new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                name: "Topic",
                url: "View/{categoryAlias}/{topicAlias}",
                defaults: new { controller = "Topic", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Sections", action = "Index" }
            );
        }
    }
}
