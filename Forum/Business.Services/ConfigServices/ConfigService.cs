using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ConfigServices
{
    public class ConfigService : ServiceBase, IConfigService
    {
        IDatabaseContext _databaseContext;

        public ConfigService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
