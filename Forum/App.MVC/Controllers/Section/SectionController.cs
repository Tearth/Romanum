using System.Collections.Generic;
using System.Web.Mvc;
using App.MVC.ViewModels.Section;
using AutoMapper;
using Business.Services.SectionServices;

namespace App.MVC.Controllers.Section
{
    public class SectionController : Controller
    {
        private ISectionService _sections;

        public SectionController(ISectionService sections)
        {
            _sections = sections;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var sections = _sections.GetAllSectionsWithCategories();
            var sectionsViewModel = Mapper.Map<IEnumerable<SectionWithCategoriesViewModel>>(sections);

            return View(sectionsViewModel);
        }
    }
}