using App.Services.ViewModels;
using AutoMapper;
using Domain.Services.PostServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.PostServices
{
    public class PostAppService : ServiceBase, IPostAppService
    {
        IPostService _postService;

        public PostAppService(IPostService postService)
        {
            _postService = postService;
        }

        public PostViewModel GetPost()
        {
            return Mapper.Map<PostViewModel>(_postService.GetPost());
        }
    }
}
