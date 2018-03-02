using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace App.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Make sure that all necessary assemblies are loaded
            Services.Bootloader.Init();
            Business.Services.Bootloader.Init();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            DIConfiguration.SetDependeciesResolver();
            MapperConfig.RegisterProfiles();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Fatal(Server.GetLastError());
        }
    }
}
