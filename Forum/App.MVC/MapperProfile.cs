using App.MVC.ViewModels.Category;
using App.MVC.ViewModels.Section;
using AutoMapper;
using Business.Services.DTO.Section;
using Business.Services.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.MVC.ViewModels.Topic;
using Business.Services.DTO.Topic;
using App.MVC.ViewModels.Registration;
using App.Services.DTO.Auth;
using App.MVC.ViewModels.LogIn;

namespace App.MVC
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SectionWithCategoriesViewModel, SectionWithCategoriesDTO>().ReverseMap();
            CreateMap<CategoryDetalisViewModel, CategoryDetailsDTO>().ReverseMap();
            CreateMap<CategoryWithTopicsViewModel, CategoryWithPostsDTO>().ReverseMap();
            CreateMap<TopicDetailsViewModel, TopicDetailsDTO>().ReverseMap();
            CreateMap<TopicWithPostsViewModel, TopicWithPostsDTO>().ReverseMap();
            CreateMap<PostViewModel, PostDTO>().ReverseMap();
            CreateMap<RegistrationViewModel, RegistrationDTO>().ReverseMap();
            CreateMap<LogInViewModel, LogInDTO>().ReverseMap();
        }
    }
}