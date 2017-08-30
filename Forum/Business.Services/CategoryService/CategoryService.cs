using Business.Services;
using DataAccess.Database;
using Domain.Services.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.CategoryService
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
            var categoryWithPosts = _databaseContext
                .Categories.Where(category => category.Alias == categoryAlias)
                .Select(category => new CategoryWithPostsDTO()
                {
                    Name = category.Name,
                    Alias = category.Alias,
                    Topics = category.Topics.Select(topic => new TopicDetailsDTO()
                    {
                        Name = topic.Name,
                        Alias = topic.Alias,
                        UniqueNumber = topic.ID,
                        CreateTime = topic.CreateTime,
                        AuthorName = "Foo bar",
                        PostsCount = topic.Posts.Count,
                        LastPostAuthorName = "Lorem Ipsum",
                        LastPostTime = topic.Posts.Max(post => post.CreateTime)
                    })
                }).Single();

            return categoryWithPosts;
        }

        public bool CategoryExists(String categoryAlias)
        {
            return _databaseContext.Categories.Any(p => p.Alias == categoryAlias);
        }
    }
}
