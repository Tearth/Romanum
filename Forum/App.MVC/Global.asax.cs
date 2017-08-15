using App.MVC.Controllers;
using Autofac.Integration.Mvc;
using Infrastructure;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitInfrastructure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Fatal(exception);
    }

        void InitInfrastructure()
        {
            var bootloader = new Bootloader();

            bootloader.InitDatabase();
            bootloader.InitMapper();

            var dependenciesBuilder = bootloader.InitDependencyContainer();
            dependenciesBuilder.RegisterControllers(typeof(HomeController).Assembly);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(dependenciesBuilder.Build()));
        }
    }
}
