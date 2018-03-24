using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AvatarFilesServices
{
    /// <summary>
    /// Represents an interface for avatar files services.
    /// </summary>
    public interface IAvatarFilesService
    {
        /// <summary>
        /// Saves avatar file and generates unique path name.
        /// </summary>
        /// <param name="stream">The file stream to save.</param>
        /// <param name="mimeType">The file mime type.</param>
        /// <param name="serverPath">The full path to the main directory.</param>
        /// <returns>The path to the saved avatar.</returns>
        string SaveAvatar(Stream stream, string mimeType, string serverPath);
    }
}
