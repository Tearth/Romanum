using System.Web.Mvc;
using App.MVC.ViewModels.LogIn;
using App.Services.AuthServices;
using App.Services.DTO.Auth;
using AutoMapper;

namespace App.MVC.Controllers.Security
{
    public class LogInController : Controller
    {
        private IAuthService _authService;

        public LogInController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogInViewModel viewModel)
        {
            var logInDTO = Mapper.Map<LogInDTO>(viewModel);

            if(!_authService.LogIn(logInDTO))
            {
                ModelState.AddModelError("UserName", "Incorrent username or password");
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