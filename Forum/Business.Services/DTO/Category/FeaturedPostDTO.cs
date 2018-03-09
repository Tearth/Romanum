using System;

namespace Business.Services.DTO.Category
{
    /// <summary>
    /// Represents the featured post (like first/last post in topic etc.).
    /// </summary>
    public class FeaturedPostDTO
    {
        /// <summary>
        /// Gets or sets the post author name.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the featured post creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
