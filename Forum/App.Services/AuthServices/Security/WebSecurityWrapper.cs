using System;
using App.Services.DTO.Auth;
using WebMatrix.WebData;

namespace App.Services.AuthServices.Security
{
    /// <summary>
    /// Represents a WebSecurity wrapper which is easier to do unit tests than static methods.
    /// </summary>
    public class WebSecurityWrapper : ServiceBase, IWebSecurityWrapper
    {
        private const string ConnectionStringName = "MainDB";
        private const string UserTableName = "Users";
        private const string UserIDColumn = "ID";
        private const string UserNameColumn = "Name";

        private static bool _ready;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSecurityWrapper"/> class.
        /// </summary>
        public WebSecurityWrapper()
        {
            if (!_ready)
            {
                WebSecurity.InitializeDatabaseConnection(ConnectionStringName, UserTableName, UserIDColumn, UserNameColumn, true);
                _ready = true;
            }
        }

        /// <inheritdoc />
        public void CreateUser(RegistrationDTO user)
        {
            WebSecurity.CreateUserAndAccount(user.UserName, user.Password, new
            {
                EMail = user.EMail,
                JoinTime = DateTime.Now,
                AvatarID = 1
            });
        }

        /// <inheritdoc />
        public bool UserExists(string name)
        {
            return WebSecurity.UserExists(name);
        }

        /// <inheritdoc />
        public bool IsUserLoggedIn()
        {
            return WebSecurity.IsAuthenticated;
        }

        /// <inheritdoc />
        public bool LogIn(LogInDTO data)
        {
            return WebSecurity.Login(data.UserName, data.Password, data.RememberMe);
        }

        /// <inheritdoc />
        public void LogOut()
        {
            WebSecurity.Logout();
        }

        /// <inheritdoc />
        public bool ChangePassword(ChangePasswordDTO data)
        {
            return WebSecurity.ChangePassword(data.Name, data.OldPassword, data.NewPassword);
        }

        /// <inheritdoc />
        public CurrentUserDTO GetCurrentUser()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                return null;
            }

            return new CurrentUserDTO
            {
                ID = WebSecurity.CurrentUserId,
                Name = WebSecurity.CurrentUserName
            };
        }
    }
}
