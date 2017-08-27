using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace App.MVC
{
    public class Dependencies : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            base.Load(builder);
        }
    }
}