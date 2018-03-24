using System.Web.Mvc;
using App.MVC.ViewModels.ControlPanel;
using App.MVC.ViewModels.ControlPanel.Enums;
using App.Services.AuthServices;
using App.Services.AvatarFilesServices;
using AutoMapper;
using Business.Services.AvatarServices;
using Business.Services.DTO.Avatar;

namespace App.MVC.Controllers.ControlPanel
{
    public class ChangeAvatarController : Controller
    {
        private IAuthService _authService;
        private IAvatarService _avatarService;
        private IAvatarFilesService _avatarFilesService;

        public ChangeAvatarController(IAuthService authService, IAvatarService avatarService, IAvatarFilesService avatarFilesService)
        {
            _authService = authService;
            _avatarService = avatarService;
            _avatarFilesService = avatarFilesService;
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
            var userID = _authService.GetCurrentUser().ID;

            switch (viewModel.Type)
            {
                case AvatarType.Default:
                {
                    _avatarService.SetUserAvatarToDefault(userID);
                    break;
                }

                case AvatarType.Gravatar:
                {
                    break;
                }

                case AvatarType.Internal:
                {
                    var stream = viewModel.AvatarFile.InputStream;
                    var mimeType = viewModel.AvatarFile.ContentType;
                    var serverPath = HttpContext.Server.MapPath("/");

                    if (viewModel.AvatarFile == null)
                    {
                        ModelState.AddModelError("AvatarFile", "You have to upload file.");
                        return View(viewModel);
                    }

                    if (!_avatarService.CheckIfMimeTypeIsValid(mimeType))
                    {
                        ModelState.AddModelError("AvatarFile", $"{mimeType} is not allowed.");
                        return View(viewModel);
                    }

                    var pathToAvatarFile = _avatarFilesService.SaveAvatar(stream, mimeType, serverPath);
                    var avatar = Mapper.Map<ChangedAvatarDTO>(viewModel);
                    avatar.Source = pathToAvatarFile;

                    _avatarService.SetUserAvatar(userID, avatar);
                    break;
                }
            }

            return RedirectToAction("Index");
        }
    }
}