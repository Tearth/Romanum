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
        bool ProfileExists(int id);
        void ChangeProfile(int id, ChangeProfileDTO profileData);
        ProfileDTO GetProfileByUserID(int id);
    }
}
