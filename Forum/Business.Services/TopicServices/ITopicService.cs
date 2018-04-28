using Business.Services.DTO.Topic;
using Business.Services.TopicServices.Exceptions;

namespace Business.Services.TopicServices
{
    /// <summary>
    /// Represents an interface for topic service.
    /// </summary>
    public interface ITopicService
    {
        /// <summary>
        /// Gets the topic information with the specified alias.
        /// </summary>
        /// <param name="topicAlias">The topic alias.</param>
        /// <exception cref="TopicNotFoundException">Thrown when a topic with the specified id doesn't exists.</exception>
        /// <returns>The topic information.</returns>
        TopicWithPostsDTO GetTopicWithPosts(string topicAlias);

        /// <summary>
        /// Checks if a topic with the specified alias exists.
        /// </summary>
        /// <param name="topicAlias">The topic alias to check.</param>
        /// <returns>True if a topic with the specified alias exists, otherwise false.</returns>
        bool Exists(string topicAlias);

        /// <summary>
        /// Validates topic and category aliases (checks if the topic is associated with
        /// the category).
        /// </summary>
        /// <param name="topicAlias">The topic alias.</param>
        /// <param name="categoryAlias">The category alias.</param>
        /// <returns>True if topic and category alias are valid together, otherwise false.</returns>
        bool ValidateTopicAndCategoryAlias(string topicAlias, string categoryAlias);

        /// <summary>
        /// Adds new post to the topic with the specified alias.
        /// </summary>
        /// <param name="topicAlias">The topic alias.</param>
        /// <param name="post">The new post to add.</param>
        /// <exception cref="TopicNotFoundException">Thrown when a topic with the specified id doesn't exists.</exception>
        void AddPost(string topicAlias, NewPostDTO post);
    }
}
