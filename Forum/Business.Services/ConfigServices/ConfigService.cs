using DataAccess.Database;
using DataAccess.Entities.Content;
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

        public T GetValue<T>(string key)
        {
            if (!KeyExists(key))
                throw new KeyNotFoundException();

            var rawValue = _databaseContext.Configuration.First(p => p.Key == key).Value;
            var convertedValue = Convert.ChangeType(rawValue, typeof(T));

            return (T)convertedValue;
        }

        public void CreateOrUpdateKey<T>(string key, T value)
        {
            Config config;

            if (!KeyExists(key))
            {
                config = new Config(key);
                _databaseContext.Configuration.Add(config);
            }
            else
            {
                config = _databaseContext.Configuration.First(p => p.Key == key);
            }

            config.Value = (string)Convert.ChangeType(value, typeof(string));

            _databaseContext.SaveChanges();
        }

        public bool KeyExists(string key)
        {
            return _databaseContext.Configuration.Any(p => p.Key == key);
        }

        public void RemoveKey(string key)
        {
            if (!KeyExists(key))
                throw new KeyNotFoundException();

            var record = _databaseContext.Configuration.First(p => p.Key == key);
            _databaseContext.Configuration.Remove(record);
        }
    }
}
