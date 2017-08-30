using Business.Services.DTO.Post;
using Business.Services.DTO.Topic;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.TopicServices
{
    public class TopicService : ServiceBase, ITopicService
    {
        IDatabaseContext _databaseContext;

        public TopicService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public TopicWithPostsDTO GetTopicWithPosts(string topicAlias, int topicID)
        {
            var topicWithPosts = _databaseContext
                .Topics.Where(topic => topic.ID == topicID && topic.Alias == topicAlias)
                .Select(topic => new TopicWithPostsDTO()
                {
                    ID = topic.ID,
                    Name = topic.Name,
                    Alias = topic.Alias,
                    Posts = topic.Posts.Select(post => new PostDTO()
                    {
                        ID = post.ID,
                        CreateTime = post.CreateTime,
                        ModifyTime = post.ModifyTime,
                        Content = post.Content
                    })
                }).Single();

            return topicWithPosts;
        }

        public bool ValidateAliasAndID(string topicAlias, int topicID)
        {
            return _databaseContext.Topics.Any(topic => topic.Alias == topicAlias && 
                                                        topic.ID == topicID);
        }
    }
}
