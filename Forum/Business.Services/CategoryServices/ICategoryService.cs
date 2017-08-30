using Business.Services.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        CategoryWithPostsDTO GetCategoryWithPosts(string categoryAlias);

        bool Exists(string categoryAlias);
    }
}
