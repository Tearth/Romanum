﻿using App.MVC.ViewModels.ControlPanel;
using App.Services.AuthServices;
using AutoMapper;
using Business.Services.DTO.Profile;
using Business.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers.ControlPanel
{
    public class ChangeProfileController : Controller
    {
        private IAuthService _authService;
        private IProfileService _profileService;

        public ChangeProfileController(IAuthService authService, IProfileService profileService)
        {
            _authService = authService;
            _profileService = profileService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currentUserID = _authService.GetCurrentUser().ID;
            var profileDTO = _profileService.GetProfileByUserID(currentUserID);

            var viewModel = Mapper.Map<ChangeProfileViewModel>(profileDTO);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ChangeProfileViewModel viewModel)
        {
            var currentUserID = _authService.GetCurrentUser().ID;
            var profileDTO = Mapper.Map<ChangeProfileDTO>(viewModel);

            _profileService.ChangeProfile(currentUserID, profileDTO);

            return RedirectToAction("Index");
        }
    }
}