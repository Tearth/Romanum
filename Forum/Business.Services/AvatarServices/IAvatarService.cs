using Business.Services.DTO.Avatar;

namespace Business.Services.AvatarServices
{
    public interface IAvatarService
    {
        AvatarDTO GetUserAvatar(int userID);
        void SetUserAvatarToDefault(int userID);
        void SetUserAvatar(int userID, AvatarTypeDTO type, string imageSource);
    }
}
