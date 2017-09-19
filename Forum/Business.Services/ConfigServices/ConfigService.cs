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

        public object GetValue<T>(string key)
        {
            if (!KeyExists(key))
                throw new KeyNotFoundException();

            var rawValue = _databaseContext.Configuration.First(p => p.Key == key);
            var convertedValue = Convert.ChangeType(rawValue, typeof(T));

            return convertedValue;
        }

        public bool KeyExists(string key)
        {
            return _databaseContext.Configuration.Any(p => p.Key == key);
        }
    }
}
