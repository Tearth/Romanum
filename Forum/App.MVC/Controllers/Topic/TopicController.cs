using System;
using System.Web;
using System.Web.Mvc;
using App.MVC.ViewModels.Topic;
using App.Services.AuthServices;
using AutoMapper;
using Business.Services.DTO.Topic;
using Business.Services.PostServices;
using Business.Services.TopicServices;

namespace App.MVC.Controllers.Topic
{
    public class TopicController : Controller
    {
        private ITopicService _topicService;
        private IPostValidator _postValidator;
        private IAuthService _authService;

        public TopicController(ITopicService topicService, IPostValidator postValidator, IAuthService authService)
        {
            _topicService = topicService;
            _postValidator = postValidator;
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Index(string categoryAlias, string topicAlias)
        {
            if (!_topicService.ValidateTopicAndCategoryAlias(topicAlias, categoryAlias))
            {
                throw new HttpException(404, "Not found"); //TODO
            }

            var topic = _topicService.GetTopicWithPosts(topicAlias);
            var topicViewModel = Mapper.Map<TopicWithPostsViewModel>(topic);

            return View(topicViewModel);
        }

        [HttpGet]
        public ActionResult SendPost(string categoryAlias, string topicAlias)
        {
            var viewModel = new SendPostViewModel
            {
                CategoryAlias = categoryAlias,
                TopicAlias = topicAlias,
                Content = TempData.ContainsKey("SendPostContent") ? (string)TempData["SendPostContent"] : string.Empty
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendPost(SendPostViewModel viewModel)
        {
            if (viewModel.Content == null || !_postValidator.IsValid(viewModel.Content))
            {
                TempData.Add("SendPostContent", viewModel.Content);
                TempData.Add("SendPostError", "The post has invalid content.");
            }
            else if(_topicService.ValidateTopicAndCategoryAlias(viewModel.TopicAlias, viewModel.CategoryAlias))
            {
                var postDTO = Mapper.Map<NewPostDTO>(viewModel);
                postDTO.AuthorID = _authService.GetCurrentUser().ID;

                _topicService.AddPost(viewModel.TopicAlias, postDTO);
            }

            return RedirectToAction("Index", new { categoryAlias = viewModel.CategoryAlias, topicAlias = viewModel.TopicAlias });
        }
    }
}