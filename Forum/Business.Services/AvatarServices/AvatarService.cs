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

        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarService"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public AvatarService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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
            RemoveUserAvatar(user);
        }

        /// <inheritdoc />
        public void SetUserAvatar(int userID, ChangedAvatarDTO changedAvatar)
        {
            if (!_databaseContext.Users.Any(p => p.ID == userID))
            {
                throw new UserProfileNotFoundException();
            }

            var user = _databaseContext.Users.First(p => p.ID == userID);
            RemoveUserAvatar(user);

            var avatar = AddAvatar(changedAvatar);
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

        private Avatar AddAvatar(ChangedAvatarDTO changedAvatar)
        {
            var avatar = Mapper.Map<Avatar>(changedAvatar);

            _databaseContext.Avatars.Add(avatar);
            _databaseContext.SaveChanges();

            return avatar;
        }
    }
}
