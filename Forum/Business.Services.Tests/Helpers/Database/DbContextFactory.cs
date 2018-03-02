using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Tests.Helpers.Database
{
    public static class DbContextFactory
    {
        private static bool Ready;
        private static object ReadyLock = new object();

        private const string DatabaseConnectionStringName = "TestDB";

        public static void Init()
        {
            lock(ReadyLock)
            {
                if (!Ready)
                {
                    System.Data.Entity.Database.SetInitializer(new TestDataInitializer());

                    var context = new DatabaseContext(DatabaseConnectionStringName);
                    context.Database.Initialize(true);

                    Ready = true;
                }
            }
        }

        public static IDatabaseContext Create()
        {
            return new DatabaseContext(DatabaseConnectionStringName);
        }
    }
}
