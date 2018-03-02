using System.Web.Mvc;
using System.Web.Routing;

namespace App.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Category",
                "View/{categoryAlias}",
                new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                "Topic",
                "View/{categoryAlias}/{topicAlias}",
                new { controller = "Topic", action = "Index" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new { controller = "Section", action = "Index" }
            );
        }
    }
}
