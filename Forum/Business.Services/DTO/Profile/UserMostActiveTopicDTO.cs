namespace Business.Services.DTO.Profile
{
    /// <summary>
    /// Represents the user's most active topic information.
    /// </summary>
    public class UserMostActiveTopicDTO
    {
        /// <summary>
        /// Gets or sets the user's most active topic name.
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// Gets or sets the user's most active topic alias.
        /// </summary>
        public string TopicAlias { get; set; }

        /// <summary>
        /// Gets or sets the user's most active category alias where the topic is stored.
        /// </summary>
        public string TopicCategoryAlias { get; set; }
    }
}
