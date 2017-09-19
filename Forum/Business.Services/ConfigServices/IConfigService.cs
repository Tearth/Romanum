using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ConfigServices
{
    public interface IConfigService
    {
        T GetValue<T>(string key);
        void SetValue<T>(string key, T value);

        bool KeyExists(string key);
    }
}
