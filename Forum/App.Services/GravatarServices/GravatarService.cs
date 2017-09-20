using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.GravatarServices
{
    public class GravatarService : ServiceBase, IGravatarService
    {
        public GravatarService()
        {

        }

        public string GetAvatarHash(string userEMail)
        {
            var md5 = MD5.Create();
            var userEMailBytes = ASCIIEncoding.UTF8.GetBytes(userEMail);

            var hashBytes = md5.ComputeHash(userEMailBytes);

            return ASCIIEncoding.UTF8.GetString(hashBytes);
        }
    }
}
