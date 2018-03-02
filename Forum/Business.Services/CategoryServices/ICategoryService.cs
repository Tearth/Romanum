using Business.Services.DTO.Category;

namespace Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        CategoryWithPostsDTO GetCategoryWithPosts(string categoryAlias);

        bool Exists(string categoryAlias);
    }
}
