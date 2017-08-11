﻿using AutoMapper;
using Domain.Entities;
using Domain.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostDTO, Post>().ReverseMap();
        }
    }
}
