using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class TopicController : Controller
    {
        public TopicController()
        {

        }

        [HttpGet]
        public ActionResult Index(string categoryAlias, string topicAlias, int topicUniqueNumber)
        {
            return View();
        }
    }
}