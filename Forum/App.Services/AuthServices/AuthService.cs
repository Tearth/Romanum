using App.Services.AuthServices.Security;
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
    }
}
