using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace App.MVC
{
    internal class DIConfiguration
    {
        public static void SetDependeciesResolver()
        {
            var builder = new ContainerBuilder();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyModules(assemblies);

            var dependenciesResolver = new AutofacDependencyResolver(builder.Build());

            DependencyResolver.SetResolver(dependenciesResolver);
        }
    }
}