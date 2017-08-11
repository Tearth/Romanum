using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Infrastructure.Migrations;

namespace Infrastructure
{
    public class Bootloader
    {
        public void InitDatabase()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public void InitDependencyContainer()
        {

        }

        public void InitMapper()
        {

        }
    }
}
