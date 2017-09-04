using App.Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class RegistrationController : Controller
    {
        IAuthService _authService;

        public RegistrationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}