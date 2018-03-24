using System.Web.Mvc;
using App.MVC.ViewModels.ControlPanel;
using App.MVC.ViewModels.ControlPanel.Enums;
using App.Services.AuthServices;
using AutoMapper;
using Business.Services.AvatarServices;

namespace App.MVC.Controllers.ControlPanel
{
    public class ChangeAvatarController : Controller
    {
        private IAuthService _authService;
        private IAvatarService _avatarService;

        public ChangeAvatarController(IAuthService authService, IAvatarService avatarService)
        {
            _authService = authService;
            _avatarService = avatarService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var currentUser = _authService.GetCurrentUser();
            var userAvatar = _avatarService.GetUserAvatar(currentUser.ID);

            var userAvatarViewModel = Mapper.Map<ChangeAvatarViewModel>(userAvatar);
            return View(userAvatarViewModel);
        }

        [HttpPost]
        public ActionResult Index(ChangeAvatarViewModel viewModel)
        {
            if (viewModel.Type == AvatarType.Internal)
            {
                if (viewModel.AvatarFile == null)
                {
                    ModelState.AddModelError("AvatarFile", "You have to upload file.");
                    return View(viewModel);
                }
            }

            return View();
        }
    }
}