using App.MVC.ViewModels.Category;
using AutoMapper;
using Business.Services.CategoryServices;
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

        [HttpGet]
        public ActionResult Index(string categoryAlias)
        {
            var category = _categoryService.GetCategoryWithPosts(categoryAlias);
            var viewModel = Mapper.Map<CategoryWithTopicsViewModel>(category);

            return View(viewModel);
        }
    }
}