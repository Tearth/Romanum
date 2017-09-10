using Business.Services.DTO.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProfileServices
{
    public interface IProfileService
    {
        bool UserNameExists(string userName);
        bool EMailExists(string email);
        ProfileDTO GetProfileByUserID(int id);
    }
}
