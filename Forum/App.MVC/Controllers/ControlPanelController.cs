using Business.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers
{
    public class ControlPanelController : Controller
    {
        IProfileService _profileService;

        public ControlPanelController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var qwe = _profileService.GetProfileByUserID(2);
            return View();
        }
    }
}