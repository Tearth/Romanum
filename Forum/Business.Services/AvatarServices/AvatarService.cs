using Business.Services.DTO.Avatar;
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

        public void SetUserAvatarToDefault(int userID)
        {
            var user = _databaseContext.Users.First(p => p.ID == userID);
            RemoveUserAvatar(user);
        }

        public void SetUserAvatar(int userID, AvatarTypeDTO type, string imageSource)
        {
            var user = _databaseContext.Users.First(p => p.ID == userID);
            RemoveUserAvatar(user);

            var avatar = AddAvatar(type, imageSource);
            user.AvatarID = avatar.ID;

            _databaseContext.SaveChanges();
        }

        void RemoveUserAvatar(User user)
        {
            if(user.AvatarID != null)
            {
                _databaseContext.Avatars.Remove(user.Avatar);
                user.AvatarID = null;
            }

            _databaseContext.SaveChanges();
        }

        Avatar AddAvatar(AvatarTypeDTO type, string imageSource)
        {
            var avatar = new Avatar()
            {
                Type = (AvatarType)type,
                Source = imageSource
            };

            _databaseContext.Avatars.Add(avatar);
            _databaseContext.SaveChanges();

            return avatar;
        }
    }
}
