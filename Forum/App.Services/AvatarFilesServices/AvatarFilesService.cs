using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AvatarFilesServices
{
    /// <summary>
    /// Represents a set of methods to manage avatar files.
    /// </summary>
    public class AvatarFilesService : ServiceBase, IAvatarFilesService
    {
        private const string AvatarsPath = "Content/Avatars/";

        /// <inheritdoc />
        public string SaveAvatar(Stream stream, string mimeType, string serverPath)
        {
            var extension = mimeType.Split('/').Last();
            var path = $"{AvatarsPath}{Guid.NewGuid()}.{extension}";
            var fullPath = $"{serverPath}{path}";

            using (var file = File.Create(fullPath))
            {
                var buffer = new byte[1024];
                int len;

                while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    file.Write(buffer, 0, len);
                }
            }

            return path;
        }
    }
}
