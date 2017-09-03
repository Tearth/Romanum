using App.Services.AuthServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services.DTO.Auth;

namespace App.Services.Tests.Helpers
{
    public class FakeWebSecurityWrapper : IWebSecurityWrapper
    {
        public bool ChangePassword(ChangePasswordDTO data)
        {
            return false;
        }

        public void CreateUser(NewUserDTO user)
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
