using App.Services.PostServices;
using App.Services.SectionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class SectionsController : Controller
    {
        ISectionAppService _sectionAppService;

        public SectionsController(ISectionAppService sectionAppService)
        {
            _sectionAppService = sectionAppService;
        }

        public ActionResult Index()
        {
            return View(_sectionAppService.GetAllSectionsWithDetails());
        }
    }
}