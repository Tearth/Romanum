﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class RegistrationController : Controller
    {
        public RegistrationController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}