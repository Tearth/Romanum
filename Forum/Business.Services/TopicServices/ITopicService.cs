using Business.Services.DTO.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.TopicServices
{
    public interface ITopicService
    {
        TopicWithPostsDTO GetTopicWithPosts(string topicAlias, int topicID);

        bool Exists(string topicAlias);
        bool ValidateTopicAndCategoryAlias(string topicAlias, string categoryAlias);
    }
}
