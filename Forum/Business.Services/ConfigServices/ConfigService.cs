using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Database;
using DataAccess.Entities;

namespace Business.Services.ConfigServices
{
    /// <summary>
    /// Represents a set of methods to manage configuration.
    /// </summary>
    public class ConfigService : ServiceBase, IConfigService
    {
        private IDatabaseContext _databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigService"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public ConfigService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <inheritdoc />
        public T GetValue<T>(string key)
        {
            if (!KeyExists(key))
            {
                throw new KeyNotFoundException();
            }

            var rawValue = _databaseContext.Configs.First(p => p.Key == key).Value;
            var convertedValue = Convert.ChangeType(rawValue, typeof(T));

            return (T)convertedValue;
        }

        /// <inheritdoc />
        public void CreateOrUpdateKey<T>(string key, T value)
        {
            Config config;

            if (!KeyExists(key))
            {
                config = new Config
                {
                    Key = key
                };

                _databaseContext.Configs.Add(config);
            }
            else
            {
                config = _databaseContext.Configs.First(p => p.Key == key);
            }

            config.Value = (string)Convert.ChangeType(value, typeof(string));

            _databaseContext.SaveChanges();
        }

        /// <inheritdoc />
        public bool KeyExists(string key)
        {
            return _databaseContext.Configs.Any(p => p.Key == key);
        }

        /// <inheritdoc />
        public void RemoveKey(string key)
        {
            if (!KeyExists(key))
            {
                throw new KeyNotFoundException();
            }

            var record = _databaseContext.Configs.First(p => p.Key == key);
            _databaseContext.Configs.Remove(record);

            _databaseContext.SaveChanges();
        }
    }
}
