using App.Services.AuthServices.Security;
using App.Services.DTO.Auth;

namespace App.Services.Tests.Helpers
{
    public class FakeWebSecurityWrapper : IWebSecurityWrapper
    {
        public bool ChangePassword(ChangePasswordDTO data)
        {
            return false;
        }

        public void CreateUser(RegistrationDTO user)
        {

        }

        public CurrentUserDTO GetCurrentUser()
        {
            return null;
        }

        public bool IsUserLoggedIn()
        {
            return false;
        }

        public bool LogIn(LogInDTO data)
        {
            return false;
        }

        public void LogOut()
        {

        }

        public bool UserExists(string name)
        {
            return false;
        }
    }
}
