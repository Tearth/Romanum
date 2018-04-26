using System.Web;
using System.Web.Mvc;
using App.MVC.ViewModels.Topic;
using AutoMapper;
using Business.Services.TopicServices;

namespace App.MVC.Controllers.Topic
{
    public class TopicController : Controller
    {
        private ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
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
        public ActionResult SendPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendPost(SendPostViewModel viewModel)
        {
            return View();
        }
    }
}