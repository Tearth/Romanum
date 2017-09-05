using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProfileServices
{
    public class ProfileService : ServiceBase, IProfileService
    {
        IDatabaseContext _databaseContext;

        public ProfileService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
