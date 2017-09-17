using Business.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers.ControlPanel
{
    public class ProfileController : Controller
    {
        IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}