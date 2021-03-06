﻿using System.Web.Mvc;
using App.MVC.Filters;
using App.MVC.ViewModels.Registration;
using App.Services.AuthServices;
using App.Services.CaptchaServices;
using App.Services.DTO.Auth;
using AutoMapper;
using Business.Services.ProfileServices;

namespace App.MVC.Controllers.Security
{
    public class RegistrationController : Controller
    {
        private IAuthService _authService;
        private IProfileService _profileService;
        private ICaptchaService _captchaService;

        public RegistrationController(IAuthService authService, IProfileService profileService, ICaptchaService captchaService)
        {
            _authService = authService;
            _profileService = profileService;
            _captchaService = captchaService;
        }

        [HttpGet]
        [UseCaptcha]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [UseCaptcha]
        public ActionResult Index(RegistrationViewModel viewModel)
        {
            if (_profileService.UserNameExists(viewModel.UserName))
            {
                ModelState.AddModelError("UserName", "User name already exists.");
                return View(viewModel);
            }

            if (_profileService.EMailExists(viewModel.EMail))
            {
                ModelState.AddModelError("EMail", "E-Mail already exists.");
                return View(viewModel);
            }

            var newUserDTO = Mapper.Map<RegistrationDTO>(viewModel);
            _authService.CreateUser(newUserDTO);

            return RedirectToAction("SuccessMessage");
        }

        [HttpGet]
        public ActionResult SuccessMessage()
        {
            return View();
        }
    }
}