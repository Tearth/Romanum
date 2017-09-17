using App.MVC.ViewModels.ControlPanel;
using App.Services.AuthServices;
using App.Services.DTO.Auth;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.MVC.Controllers.ControlPanel
{
    public class ChangePasswordController : Controller
    {
        IAuthService _authService;

        public ChangePasswordController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ChangePasswordViewModel viewModel)
        {
            var changePasswordDTO = Mapper.Map<ChangePasswordDTO>(viewModel);
            changePasswordDTO.Name = _authService.GetCurrentUser().Name;

            if(!_authService.ChangePassword(changePasswordDTO))
            {
                ModelState.AddModelError("Summary", "Invalid old password, try again.");
                return View(viewModel);
            }

            return RedirectToAction("SuccessMessage");
        }

        [HttpGet]
        public ActionResult SuccessMessage()
        {
            return View();
        }
    }
}