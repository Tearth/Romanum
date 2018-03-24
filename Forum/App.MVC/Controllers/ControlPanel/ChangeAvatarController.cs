using System.Web.Mvc;
using App.MVC.ViewModels.ControlPanel;
using App.MVC.ViewModels.ControlPanel.Enums;
using App.Services.AuthServices;
using App.Services.AvatarFilesServices;
using App.Services.GravatarServices;
using AutoMapper;
using Business.Services.AvatarServices;
using Business.Services.DTO.Avatar;
using Business.Services.ProfileServices;

namespace App.MVC.Controllers.ControlPanel
{
    public class ChangeAvatarController : Controller
    {
        private IAuthService _authService;
        private IProfileService _profileService;
        private IAvatarService _avatarService;
        private IAvatarFilesService _avatarFilesService;
        private IGravatarService _gravatarService;

        public ChangeAvatarController(IAuthService authService, IProfileService profileService, IAvatarService avatarService, IAvatarFilesService avatarFilesService, IGravatarService gravatarService)
        {
            _authService = authService;
            _profileService = profileService;
            _avatarService = avatarService;
            _avatarFilesService = avatarFilesService;
            _gravatarService = gravatarService;
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
                    var userEMail = _profileService.GetProfileByUserID(userID).EMail;
                    var gravatarLink = _gravatarService.GetGravatarLink(userEMail);

                    var changeAvatarDTO = new ChangedAvatarDTO()
                    {
                        Type = AvatarTypeDTO.Gravatar,
                        Source = gravatarLink
                    };

                    _avatarService.SetUserAvatar(userID, changeAvatarDTO);
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