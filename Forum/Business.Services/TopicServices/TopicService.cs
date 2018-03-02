﻿using System.Linq;
using Business.Services.DTO.Topic;
using Business.Services.TopicServices.Exceptions;
using DataAccess.Database;

namespace Business.Services.TopicServices
{
    public class TopicService : ServiceBase, ITopicService
    {
        private IDatabaseContext _databaseContext;

        public TopicService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public TopicWithPostsDTO GetTopicWithPosts(string topicAlias)
        {
            if (!Exists(topicAlias))
            {
                throw new TopicNotFoundException();
            }

            var topicQuery = _databaseContext.Topics.Where(topic => topic.Alias == topicAlias);
            var topicWithPosts = topicQuery.Select(topic => new TopicWithPostsDTO
            {
                ID = topic.ID,
                Name = topic.Name,
                Alias = topic.Alias,
                Posts = topic.Posts.Select(post => new PostDTO
                {
                    ID = post.ID,
                    CreationTime = post.CreationTime,
                    ModificationTime = post.ModificationTime,
                    Content = post.Content,

                    AuthorName = post.Author.Name,
                    AuthorPostsCount = post.Author.Posts.Count,
                    AuthorJoinTime = post.Author.JoinTime,
                    AuthorCity = post.Author.City,
                    AuthorFooter = post.Author.Footer
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
