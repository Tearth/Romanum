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
        TopicWithPostsDTO GetTopicWithPosts(int topicID);

        bool ValidateAliasAndID(string topicAlias, int topicID);
    }
}
