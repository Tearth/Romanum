using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Infrastructure.Migrations;
using Autofac;
using System.Reflection;

namespace Infrastructure
{
    public class Bootloader
    {
        public void InitDatabase()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public ContainerBuilder InitDependencyContainer()
        {
            var dependenciesBuilder = new ContainerBuilder();

            dependenciesBuilder.RegisterModule(new App.Services.Dependencies());
            dependenciesBuilder.RegisterModule(new Domain.Services.Dependencies());

            return dependenciesBuilder;
        }

        public void InitMapper()
        {

        }
    }
}
