using Business.Services.DTO.Avatar;
using DataAccess.Database;
using DataAccess.Entities;
using DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;

namespace Business.Services.AvatarServices
{
    public class AvatarService : ServiceBase, IAvatarService
    {
        private IDatabaseContext _databaseContext;

        public AvatarService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public AvatarDTO GetUserAvatar(int userID)
        {
            var avatar = _databaseContext.Users
                .Include(user => user.Avatar)
                .First(p => p.ID == userID).Avatar;

            var avatarDTO = Mapper.Map<AvatarDTO>(avatar);
            return avatarDTO;
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

        private void RemoveUserAvatar(User user)
        {
            if(user.AvatarID != null)
            {
                _databaseContext.Avatars.Remove(user.Avatar);
                user.AvatarID = null;
            }

            _databaseContext.SaveChanges();
        }

        private Avatar AddAvatar(AvatarTypeDTO type, string imageSource)
        {
            var avatar = new Avatar
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
