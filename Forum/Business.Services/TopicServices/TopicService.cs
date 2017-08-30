using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.TopicServices
{
    public class TopicService : ServiceBase, ITopicService
    {
        IDatabaseContext _databaseContext;

        public TopicService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
