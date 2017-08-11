using App.Services.PostServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class HomeController : Controller
    {
        IPostAppService _postAppService;

        public HomeController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        public ActionResult Index()
        {
            return View(_postAppService.GetPost());
        }
    }
}