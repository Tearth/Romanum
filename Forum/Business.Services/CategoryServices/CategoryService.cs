using System.Linq;
using Business.Services.CategoryServices.Exceptions;
using Business.Services.DTO.Category;
using DataAccess.Database;

namespace Business.Services.CategoryServices
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private IDatabaseContext _databaseContext;

        public CategoryService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public CategoryWithPostsDTO GetCategoryWithPosts(string categoryAlias)
        {
            if (!Exists(categoryAlias))
            {
                throw new CategoryNotFoundException();
            }

            var categoryQuery = _databaseContext.Categories.Where(category => category.Alias == categoryAlias);

            var categoryWithPosts = categoryQuery.OrderBy(category => category.Order).Select(category => new CategoryWithPostsDTO
            {
                ID = category.ID,
                Name = category.Name,
                Alias = category.Alias,
                Order = category.Order,
                Topics = category.Topics.Select(topic => new TopicDetailsDTO
                {
                    ID = topic.ID,
                    Name = topic.Name,
                    Alias = topic.Alias,
                    PostsCount = topic.Posts.Count,

                    FirstPost = topic.Posts
                        .OrderByDescending(p => p.CreationTime)
                        .Select(post => new FeaturedPostDTO
                        {
                            AuthorName = post.Author.Name,
                            CreationTime = post.CreationTime
                        }).FirstOrDefault(),

                    LastPost = topic.Posts
                        .OrderBy(p => p.CreationTime)
                        .Select(post => new FeaturedPostDTO
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
