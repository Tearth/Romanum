using App.Services.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace App.Services.AuthServices.Security
{
    public class WebSecurityWrapper : ServiceBase, IWebSecurityWrapper
    {
        static bool Ready = false;

        const string ConnectionStringName = "MainDB";
        const string UserTableName = "Users";
        const string UserIDColumn = "ID";
        const string UserNameColumn = "Name";

        public WebSecurityWrapper()
        {
            if(!Ready)
            {
                WebSecurity.InitializeDatabaseConnection(ConnectionStringName, UserTableName, UserIDColumn, UserNameColumn, true);
                Ready = true;
            }
        }

        public void CreateUser(NewUserDTO user)
        {
            WebSecurity.CreateUserAndAccount(user.Name, user.Password, new { EMail = user.EMail });
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
            return WebSecurity.Login(data.Name, data.Password, data.RememberMe);
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
                return null;

            return new CurrentUserDTO()
            {
                ID = WebSecurity.CurrentUserId,
                Name = WebSecurity.CurrentUserName
            };
        }
    }
}
