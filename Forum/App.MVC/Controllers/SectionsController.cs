using App.MVC.ViewModels.Section;
using AutoMapper;
using Business.Services.SectionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class SectionsController : Controller
    {
        ISectionService _sections;

        public SectionsController(ISectionService sections)
        {
            _sections = sections;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var sections = _sections.GetAllSetionsWithCategories();
            var viewModel = Mapper.Map<IEnumerable<SectionWithCategoriesViewModel>>(sections);

            return View(viewModel);
        }
    }
}