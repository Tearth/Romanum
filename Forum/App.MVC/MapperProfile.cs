﻿using App.MVC.ViewModels.Content;
using AutoMapper;
using Business.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SectionWithCategoriesViewModel, SectionWithCategoriesDTO>().ReverseMap();
            CreateMap<CategoryDetalisViewModel, CategoryDetailsDTO>().ReverseMap();
        }
    }
}