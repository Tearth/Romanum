using App.MVC.ViewModels.ControlPanel;
using App.Services.AuthServices;
using AutoMapper;
using Business.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers.ControlPanel
{
    public class ProfileOverviewController : Controller
    {
        private IProfileService _profileService;
        private IAuthService _authService;

        public ProfileOverviewController(IAuthService authService, IProfileService profileService)
        {
            _profileService = profileService;
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currentUserID = _authService.GetCurrentUser().ID;
            var profileDTO = _profileService.GetProfileByUserID(currentUserID);

            var viewModel = Mapper.Map<ProfileOverviewViewModel>(profileDTO);
            return View(viewModel);
        }
    }
}