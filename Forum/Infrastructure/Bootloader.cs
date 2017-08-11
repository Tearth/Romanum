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
using AutoMapper;

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

            dependenciesBuilder.RegisterModule(new Infrastructure.Dependencies());
            dependenciesBuilder.RegisterModule(new App.Services.Dependencies());
            dependenciesBuilder.RegisterModule(new Domain.Services.Dependencies());

            return dependenciesBuilder;
        }

        public void InitMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new App.Services.MapperProfile());
                cfg.AddProfile(new Domain.Services.MapperProfile());
            });
        }
    }
}
