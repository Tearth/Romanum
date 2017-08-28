using Domain.Services.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.CategoryService
{
    public interface ICategoryService
    {
        CategoryWithPostsDTO GetCategoryWithPosts(string categoryAlias);
    }
}
