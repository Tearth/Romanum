using DataAccess.Database;
using DataAccess.Entities;
using DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AvatarServices
{
    public class AvatarService : ServiceBase, IAvatarService
    {
        IDatabaseContext _databaseContext;

        public AvatarService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
