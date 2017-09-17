using App.MVC.ViewModels.ControlPanel;
using App.Services.AuthServices;
using AutoMapper;
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
        IAuthService _authService;

        public ControlPanelController(IAuthService authService, IProfileService profileService)
        {
            _profileService = profileService;
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currentUserID = _authService.GetCurrentUser().ID;
            var profile = _profileService.GetProfileByUserID(currentUserID);

            var viewModel = Mapper.Map<ProfileViewModel>(profile);
            return View(viewModel);
        }
    }
}