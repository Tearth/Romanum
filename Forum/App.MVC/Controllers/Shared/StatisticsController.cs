using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers.Shared
{
    [ChildActionOnly]
    public class StatisticsController : Controller
    {
        [HttpGet]
        public ActionResult Statistics()
        {
            return PartialView();
        }
    }
}