using App.MVC.ViewModels.Category;
using AutoMapper;
using Domain.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index(String categoryAlias)
        {
            var category = _categoryService.GetCategoryWithPosts(categoryAlias);
            var viewModel = Mapper.Map<CategoryWithPostsViewModel>(category);

            return View(viewModel);
        }
    }
}