using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Business.Services.DTO.Avatar;
using Business.Services.ProfileServices.Exceptions;
using DataAccess.Database;
using DataAccess.Entities;
using DataAccess.Entities.Enums;

namespace Business.Services.AvatarServices
{
    /// <summary>
    /// Represents a set of methods to manage user avatars.
    /// </summary>
    public class AvatarService : ServiceBase, IAvatarService
    {
        private IDatabaseContext _databaseContext;
        private List<string> _allowedMimeTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarService"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public AvatarService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _allowedMimeTypes = new List<string>
            {
                "image/png",
                "image/jpeg",
                "image/bmp"
            };
        }

        /// <inheritdoc />
        public AvatarDTO GetUserAvatar(int userID)
        {
            if (!_databaseContext.Users.Any(p => p.ID == userID))
            {
                throw new UserProfileNotFoundException();
            }

            var avatar = _databaseContext.Users
                .Include(user => user.Avatar)
                .First(p => p.ID == userID).Avatar;

            var avatarDTO = Mapper.Map<AvatarDTO>(avatar);
            return avatarDTO;
        }

        /// <inheritdoc />
        public void SetUserAvatarToDefault(int userID)
        {
            if (!_databaseContext.Users.Any(p => p.ID == userID))
            {
                throw new UserProfileNotFoundException();
            }

            var user = _databaseContext.Users.First(p => p.ID == userID);
            if (user.Avatar.Type != AvatarType.Default)
            {
                RemoveUserAvatar(user);
            }

            var defaultAvatar = _databaseContext.Avatars.First(p => p.Type == AvatarType.Default);

            user.AvatarID = defaultAvatar.ID;
            _databaseContext.SaveChanges();
        }

        /// <inheritdoc />
        public void SetUserAvatar(int userID, ChangedAvatarDTO changedAvatar)
        {
            if (!_databaseContext.Users.Any(p => p.ID == userID))
            {
                throw new UserProfileNotFoundException();
            }

            var user = _databaseContext.Users.First(p => p.ID == userID);
            if (user.Avatar.Type != AvatarType.Default)
            {
                RemoveUserAvatar(user);
            }

            var avatar = AddAvatar(changedAvatar);
            user.AvatarID = avatar.ID;

            _databaseContext.SaveChanges();
        }

        /// <inheritdoc />
        public bool CheckIfMimeTypeIsValid(string mimeType)
        {
            return _allowedMimeTypes.Contains(mimeType);
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

        private Avatar AddAvatar(ChangedAvatarDTO changedAvatar)
        {
            var avatar = Mapper.Map<Avatar>(changedAvatar);

            _databaseContext.Avatars.Add(avatar);
            _databaseContext.SaveChanges();

            return avatar;
        }
    }
}
