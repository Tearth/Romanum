using App.Services.DTO.Auth;

namespace App.Services.AuthServices.Security
{
    public interface IWebSecurityWrapper
    {
        void CreateUser(RegistrationDTO user);
        bool UserExists(string name);
        bool IsUserLoggedIn();
        bool LogIn(LogInDTO data);
        void LogOut();
        bool ChangePassword(ChangePasswordDTO data);
        CurrentUserDTO GetCurrentUser();
    }
}
