using App.MVC.ViewModels.Category;
using App.MVC.ViewModels.Section;
using AutoMapper;
using Business.Services.DTO.Section;
using Domain.Services.DTO.Category;
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
            CreateMap<CategoryWithPostsViewModel, CategoryWithPostsDTO>().ReverseMap();
            CreateMap<TopicDetailsViewModel, TopicDetailsDTO>().ReverseMap();
        }
    }
}