﻿using DataAccess.Database;
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

        public void SetValue<T>(string key, T value)
        {
            if (!KeyExists(key))
                throw new KeyNotFoundException();

            var record = _databaseContext.Configuration.First(p => p.Key == key);
            record.Value = (string)Convert.ChangeType(value, typeof(string));

            _databaseContext.SaveChanges();
        }

        public bool KeyExists(string key)
        {
            return _databaseContext.Configuration.Any(p => p.Key == key);
        }
    }
}