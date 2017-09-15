using Business.Services;
using DataAccess.Database;
using Business.Services.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services.CategoryServices.Exceptions;

namespace Business.Services.CategoryServices
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        IDatabaseContext _databaseContext;

        public CategoryService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public CategoryWithPostsDTO GetCategoryWithPosts(string categoryAlias)
        {
            if (!Exists(categoryAlias))
                throw new CategoryNotFoundException();

            var categoryQuery = _databaseContext.Categories.Where(category => category.Alias == categoryAlias);

            var categoryWithPosts = categoryQuery.Select(category => new CategoryWithPostsDTO()
            {
                ID = category.ID,
                Name = category.Name,
                Alias = category.Alias,
                Topics = category.Topics.Select(topic => new TopicDetailsDTO()
                {
                    ID = topic.ID,
                    Name = topic.Name,
                    Alias = topic.Alias,
                    PostsCount = topic.Posts.Count(),

                    FirstPost = topic.Posts
                        .OrderByDescending(p => p.CreationTime)
                        .Select(post => new FeaturedPostDTO()
                        {
                            AuthorName = post.Author.Name,
                            CreationTime = post.CreationTime
                        }).FirstOrDefault(),

                    LastPost = topic.Posts
                        .OrderBy(p => p.CreationTime)
                        .Select(post => new FeaturedPostDTO()
                        {
                            AuthorName = post.Author.Name,
                            CreationTime = post.CreationTime
                        }).FirstOrDefault()
                })
            }).Single();

            return categoryWithPosts;
        }

        public bool Exists(string categoryAlias)
        {
            return _databaseContext.Categories.Any(p => p.Alias == categoryAlias);
        }
    }
}
