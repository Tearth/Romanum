namespace Business.Services.DTO.Category
{
    /// <summary>
    /// Represents a topic details.
    /// </summary>
    public class TopicDetailsDTO
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
        /// Gets or sets the topic alias used in URL.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the first post in the topic.
        /// </summary>
        public FeaturedPostDTO FirstPost { get; set; }

        /// <summary>
        /// Gets or sets the last post in the topic.
        /// </summary>
        public FeaturedPostDTO LastPost { get; set; }

        /// <summary>
        /// Gets or sets the posts count.
        /// </summary>
        public int PostsCount { get; set; }
    }
}
