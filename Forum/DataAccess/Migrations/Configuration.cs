using DataAccess.Database;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            
        }
    }
}
