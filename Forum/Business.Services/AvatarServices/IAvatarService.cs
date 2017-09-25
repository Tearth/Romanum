using Business.Services.DTO.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AvatarServices
{
    public interface IAvatarService
    {
        AvatarDTO GetUserAvatar(int userID);
        void SetUserAvatarToDefault(int userID);
        void SetUserAvatar(int userID, AvatarTypeDTO type, string imageSource);
    }
}
