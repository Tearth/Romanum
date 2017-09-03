using App.MVC.App_Start;
using App.MVC.Controllers;
using Autofac.Integration.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace App.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Make sure that all necessary assemblies are loaded
            App.Services.Bootloader.Init();
            Business.Services.Bootloader.Init();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DIConfiguration.SetDependeciesResolver();
            MapperConfig.RegisterProfiles();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Fatal(Server.GetLastError());

            //Server.ClearError();
        }
    }
}
