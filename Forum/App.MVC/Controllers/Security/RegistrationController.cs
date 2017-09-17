using App.MVC.ViewModels.Registration;
using App.Services.AuthServices;
using App.Services.DTO.Auth;
using AutoMapper;
using Business.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers.Security
{
    public class RegistrationController : Controller
    {
        IAuthService _authService;
        IProfileService _profileService;

        public RegistrationController(IAuthService authService, IProfileService profileService)
        {
            _authService = authService;
            _profileService = profileService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
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