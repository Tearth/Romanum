using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {

        }

        public ActionResult Index(String alias)
        {
            return View();
        }
    }
}