using System.Security.Cryptography;
using System.Text;

namespace App.Services.GravatarServices
{
    public class GravatarService : ServiceBase, IGravatarService
    {
        private const string GravatarURL = "https://www.gravatar.com/avatar/";

        public string GetGravatarLink(string userEMail)
        {
            return GravatarURL + GetGravatarHash(userEMail);
        }

        public string GetGravatarHash(string userEMail)
        {
            var fixedEMail = userEMail.Trim().ToLower();
            var userEMailBytes = Encoding.UTF8.GetBytes(fixedEMail);

            var md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(userEMailBytes);

            var hashString = GetHashString(hashBytes);

            return hashString;
        }

        private string GetHashString(byte[] hashBytes)
        {
            var hashString = new StringBuilder();

            foreach (var b in hashBytes)
            {
                hashString.Append(b.ToString("x2"));
            }

            return hashString.ToString();
        }
    }
}
