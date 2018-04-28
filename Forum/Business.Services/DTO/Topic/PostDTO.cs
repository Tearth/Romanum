using System;

namespace Business.Services.DTO.Topic
{
    /// <summary>
    /// Represents the post information.
    /// </summary>
    public class PostDTO
    {
        /// <summary>
        /// Gets or sets the post ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the post creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the post modification time.
        /// </summary>
        public DateTime? ModificationTime { get; set; }

        /// <summary>
        /// Gets or sets the post content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the post author name.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the author avatar.
        /// </summary>
        public string AuthorAvatar { get; set; }

        /// <summary>
        /// Gets or sets the posts count of the post author.
        /// </summary>
        public int AuthorPostsCount { get; set; }

        /// <summary>
        /// Gets or sets the join time of the post author.
        /// </summary>
        public DateTime AuthorJoinTime { get; set; }

        /// <summary>
        /// Gets or sets the city of the post author.
        /// </summary>
        public string AuthorCity { get; set; }

        /// <summary>
        /// Gets or sets the footer of the post author.
        /// </summary>
        public string AuthorFooter { get; set; }
    }
}
