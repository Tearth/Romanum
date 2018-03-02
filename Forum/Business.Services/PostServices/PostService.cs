﻿using AutoMapper;
using Business.Services.DTO.Section;
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
        private IDatabaseContext _databaseContext;

        public PostService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
