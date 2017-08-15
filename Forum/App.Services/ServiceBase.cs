using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public abstract class ServiceBase
    {
        protected Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
