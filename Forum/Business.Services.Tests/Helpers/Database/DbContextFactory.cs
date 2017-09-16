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
        public static IDatabaseContext Create()
        {
            var context = new DatabaseContext("TestDB");
            return context;
        }
    }
}
