using Business.Services.DTO.Profile;

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
