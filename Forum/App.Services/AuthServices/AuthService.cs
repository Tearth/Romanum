using App.Services.AuthServices.Exceptions;
using App.Services.AuthServices.Security;
using App.Services.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AuthServices
{
    public class AuthService : ServiceBase, IAuthService
    {
        IWebSecurityWrapper _webSecurityWrapper;
        
        public AuthService(IWebSecurityWrapper webSecurityWrapper)
        {
            _webSecurityWrapper = webSecurityWrapper;
        }

        public void CreateUser(NewUserDTO user)
        {
            if (_webSecurityWrapper.UserExists(user.Name))
                throw new UserNameExistsException();

            _webSecurityWrapper.CreateUser(user);
        }

        public bool UserExists(string name)
        {
            return _webSecurityWrapper.UserExists(name);
        }

        public bool IsUserLoggedIn()
        {
            return _webSecurityWrapper.IsUserLoggedIn();
        }

        public bool LogIn(LogInDTO data)
        {
            return _webSecurityWrapper.LogIn(data);
        }

        public void LogOut()
        {
            _webSecurityWrapper.LogOut();
        }

        public bool ChangePassword(ChangePasswordDTO data)
        {
            if (_webSecurityWrapper.UserExists(data.Name))
                throw new UserNameExistsException();

            return _webSecurityWrapper.ChangePassword(data);
        }

        public CurrentUserDTO GetCurrentUser()
        {
            if (!_webSecurityWrapper.IsUserLoggedIn())
                throw new UserNotLoggedInException();

            return _webSecurityWrapper.GetCurrentUser();
        }
    }
}
