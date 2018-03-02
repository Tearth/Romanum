using NLog;

namespace Business.Services
{
    public abstract class ServiceBase
    {
        protected Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
