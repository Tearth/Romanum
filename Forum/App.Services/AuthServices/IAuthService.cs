using App.Services.DTO.Auth;

namespace App.Services.AuthServices
{
    public interface IAuthService
    {
        void CreateUser(RegistrationDTO user);
        bool IsUserLoggedIn();
        bool LogIn(LogInDTO data);
        void LogOut();
        bool ChangePassword(ChangePasswordDTO data);
        CurrentUserDTO GetCurrentUser();
    }
}
