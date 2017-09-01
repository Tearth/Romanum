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
    }
}
