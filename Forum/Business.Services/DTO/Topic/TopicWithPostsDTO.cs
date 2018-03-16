using System.Collections.Generic;

namespace Business.Services.DTO.Topic
{
    /// <summary>
    /// Represents the topic information with the associated posts.
    /// </summary>
    public class TopicWithPostsDTO
    {
        /// <summary>
        /// Gets or sets the topic ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the topic name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the topic alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the list of posts associated with the topic.
        /// </summary>
        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
