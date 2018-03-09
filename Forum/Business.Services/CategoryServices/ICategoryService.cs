using Business.Services.DTO.Category;

namespace Business.Services.CategoryServices
{
    /// <summary>
    /// Represents an interface for category service.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Gets the category information with associated list of posts.
        /// </summary>
        /// <param name="categoryAlias">The category alias.</param>
        /// <returns>The category information.</returns>
        CategoryWithPostsDTO GetCategoryWithPosts(string categoryAlias);

        /// <summary>
        /// Checks if the category with the specified alias exists.
        /// </summary>
        /// <param name="categoryAlias">The category alias.</param>
        /// <returns>True if the category with the specified alias exists, otherwise false.</returns>
        bool Exists(string categoryAlias);
    }
}
