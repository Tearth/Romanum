using App.Services.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
