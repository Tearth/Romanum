using System.Web.Mvc;
using App.MVC.ViewModels.Category;
using AutoMapper;
using Business.Services.CategoryServices;

namespace App.MVC.Controllers.Category
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Index(string categoryAlias)
        {
            var category = _categoryService.GetCategoryWithPosts(categoryAlias);
            var categoryViewModel = Mapper.Map<CategoryWithTopicsViewModel>(category);

            return View(categoryViewModel);
        }
    }
}