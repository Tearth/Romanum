using App.MVC.ViewModels.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class LogInController : Controller
    {
        public LogInController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogInViewModel viewModel)
        {
            return View();
        }
    }
}