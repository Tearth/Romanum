using NLog;

namespace App.Services
{
    public abstract class ServiceBase
    {
        protected Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
