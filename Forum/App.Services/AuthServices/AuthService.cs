using App.Services.AuthServices.Exceptions;
using App.Services.AuthServices.Security;
using App.Services.DTO.Auth;

namespace App.Services.AuthServices
{
    /// <summary>
    /// Represents a set of methods to manage user authorization.
    /// </summary>
    public class AuthService : ServiceBase, IAuthService
    {
        private IWebSecurityWrapper _webSecurityWrapper;

        public AuthService(IWebSecurityWrapper webSecurityWrapper)
        {
            _webSecurityWrapper = webSecurityWrapper;
        }

        /// <inheritdoc />
        public void CreateUser(RegistrationDTO user)
        {
            if (_webSecurityWrapper.UserExists(user.UserName))
            {
                throw new UserNameAlreadyExistsException();
            }

            _webSecurityWrapper.CreateUser(user);
        }

        /// <inheritdoc />
        public bool UserExists(string name)
        {
            return _webSecurityWrapper.UserExists(name);
        }

        /// <inheritdoc />
        public bool IsUserLoggedIn()
        {
            return _webSecurityWrapper.IsUserLoggedIn();
        }

        /// <inheritdoc />
        public bool LogIn(LogInDTO data)
        {
            return _webSecurityWrapper.LogIn(data);
        }

        /// <inheritdoc />
        public void LogOut()
        {
            if (!_webSecurityWrapper.IsUserLoggedIn())
            {
                throw new UserNotLoggedInException();
            }

            _webSecurityWrapper.LogOut();
        }

        /// <inheritdoc />
        public bool ChangePassword(ChangePasswordDTO data)
        {
            if (!_webSecurityWrapper.UserExists(data.Name))
            {
                throw new UserNameNotExistsException();
            }

            return _webSecurityWrapper.ChangePassword(data);
        }

        /// <inheritdoc />
        public CurrentUserDTO GetCurrentUser()
        {
            if (!_webSecurityWrapper.IsUserLoggedIn())
            {
                throw new UserNotLoggedInException();
            }

            return _webSecurityWrapper.GetCurrentUser();
        }
    }
}
