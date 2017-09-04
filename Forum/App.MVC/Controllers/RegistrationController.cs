using App.MVC.ViewModels.Registration;
using App.Services.AuthServices;
using App.Services.DTO.Auth;
using AutoMapper;
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

        [HttpPost]
        public ActionResult Index(RegistrationViewModel viewModel)
        {
            if (_authService.UserNameExists(viewModel.UserName))
            {
                ModelState.AddModelError("UserName", "User name already exists.");
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