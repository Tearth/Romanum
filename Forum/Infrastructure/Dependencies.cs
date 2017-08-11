using Autofac;
using Domain.Services.Database;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Dependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>();

            base.Load(builder);
        }
    }
}
