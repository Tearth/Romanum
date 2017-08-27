using AutoMapper;
using Business.Services.DTOs;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.PostServices
{
    public class PostService : ServiceBase, IPostService
    {
        IDatabaseContext _databaseContext;

        public PostService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public PostDTO GetPost()
        {
            return Mapper.Map<PostDTO>(_databaseContext.Posts.First());
        }
    }
}
