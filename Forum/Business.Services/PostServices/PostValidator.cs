using System.Linq;
using System.Collections.Generic;

namespace Business.Services.PostServices
{
    /// <summary>
    /// Represents a set of methods to validate post contents.
    /// </summary>
    public class PostValidator : ServiceBase, IPostValidator
    {
        private const int MinLength = 5;
        private const int MaxLength = 1000;

        private readonly List<string> _invalidTags = new List<string>
        {
            "applet",
            "script",
            "style",
            "link",
            "iframe"
        };

        /// <inheritdoc />
        public bool IsValid(string content)
        {
            var lowerContent = content.ToLower();
            if (lowerContent.Length < MinLength || lowerContent.Length > MaxLength)
            {
                return false;
            }

            return !_invalidTags.Any(lowerContent.Contains);
        }
    }
}
