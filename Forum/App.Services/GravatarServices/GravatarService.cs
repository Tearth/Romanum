using System.Security.Cryptography;
using System.Text;

namespace App.Services.GravatarServices
{
    /// <summary>
    /// Represents a set of methods to manage avatars from Gravatar service.
    /// </summary>
    public class GravatarService : ServiceBase, IGravatarService
    {
        private const string GravatarURL = "https://www.gravatar.com/avatar/";

        /// <inheritdoc />
        public string GetGravatarLink(string userEMail)
        {
            return GravatarURL + GetGravatarHash(userEMail);
        }

        /// <inheritdoc />
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
