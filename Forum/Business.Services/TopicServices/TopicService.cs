using Business.Services.DTO.Topic;
using Business.Services.TopicServices.Exceptions;
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

        public TopicWithPostsDTO GetTopicWithPosts(string topicAlias)
        {
            if (!Exists(topicAlias))
                throw new TopicNotFoundException(topicAlias);

            var topicWithPosts = _databaseContext
                .Topics.Where(topic => topic.Alias == topicAlias)
                .Select(topic => new TopicWithPostsDTO()
                {
                    ID = topic.ID,
                    Name = topic.Name,
                    Alias = topic.Alias,
                    Posts = topic.Posts.Select(post => new PostDTO()
                    {
                        ID = post.ID,
                        CreationTime = post.CreationTime,
                        ModificationTime = post.ModificationTime,
                        Content = post.Content
                    })
                }).Single();

            return topicWithPosts;
        }

        public bool Exists(string topicAlias)
        {
            return _databaseContext.Topics.Any(p => p.Alias == topicAlias);
        }

        public bool ValidateTopicAndCategoryAlias(string topicAlias, string categoryAlias)
        {
            return _databaseContext.Topics.Any(p => p.Alias == topicAlias && 
                                                    p.Category.Alias == categoryAlias);
        }
    }
}
