using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.App_Start
{
    internal class DIConfiguration
    {
        public static void SetDependeciesResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());

            var container = builder.Build();
            var dependenciesResolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(dependenciesResolver);
        }
    }
}