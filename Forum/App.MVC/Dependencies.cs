using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;

namespace App.MVC
{
    public class Dependencies : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();

            base.Load(builder);
        }
    }
}