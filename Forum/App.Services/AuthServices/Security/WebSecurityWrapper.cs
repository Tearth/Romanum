using System;
using App.Services.DTO.Auth;
using WebMatrix.WebData;

namespace App.Services.AuthServices.Security
{
    public class WebSecurityWrapper : ServiceBase, IWebSecurityWrapper
    {
        private static bool Ready;

        private const string ConnectionStringName = "MainDB";
        private const string UserTableName = "Users";
        private const string UserIDColumn = "ID";
        private const string UserNameColumn = "Name";

        public WebSecurityWrapper()
        {
            if(!Ready)
            {
                WebSecurity.InitializeDatabaseConnection(ConnectionStringName, UserTableName, UserIDColumn, UserNameColumn, true);
                Ready = true;
            }
        }

        public void CreateUser(RegistrationDTO user)
        {
            WebSecurity.CreateUserAndAccount(user.UserName, user.Password, new
            {
                EMail = user.EMail,
                JoinTime = DateTime.Now,
                AvatarID = 1
            });
        }

        public bool UserExists(string name)
        {
            return WebSecurity.UserExists(name);
        }

        public bool IsUserLoggedIn()
        {
            return WebSecurity.IsAuthenticated;
        }

        public bool LogIn(LogInDTO data)
        {
            return WebSecurity.Login(data.UserName, data.Password, data.RememberMe);
        }

        public void LogOut()
        {
            WebSecurity.Logout();
        }

        public bool ChangePassword(ChangePasswordDTO data)
        {
            return WebSecurity.ChangePassword(data.Name, data.OldPassword, data.NewPassword);
        }

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
