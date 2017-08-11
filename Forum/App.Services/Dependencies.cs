using App.Services.PostServices;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class Dependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(p => p.IsSubclassOf(typeof(ServiceBase)))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
