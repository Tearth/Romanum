using Business.Services.DTO.Topic;

namespace Business.Services.TopicServices
{
    public interface ITopicService
    {
        TopicWithPostsDTO GetTopicWithPosts(string topicAlias);

        bool Exists(string topicAlias);
        bool ValidateTopicAndCategoryAlias(string topicAlias, string categoryAlias);
    }
}
