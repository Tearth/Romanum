using App.MVC.ViewModels.Category;
using App.MVC.ViewModels.ControlPanel;
using App.MVC.ViewModels.LogIn;
using App.MVC.ViewModels.Registration;
using App.MVC.ViewModels.Section;
using App.MVC.ViewModels.Topic;
using App.Services.DTO.Auth;
using AutoMapper;
using Business.Services.DTO.Category;
using Business.Services.DTO.Profile;
using Business.Services.DTO.Section;
using Business.Services.DTO.Topic;

namespace App.MVC
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Section
            CreateMap<SectionWithCategoriesViewModel, SectionWithCategoriesDTO>().ReverseMap();
            CreateMap<CategoryDetalisViewModel, CategoryDetailsDTO>().ReverseMap();

            //Category
            CreateMap<CategoryWithTopicsViewModel, CategoryWithPostsDTO>().ReverseMap();
            CreateMap<TopicDetailsViewModel, TopicDetailsDTO>().ReverseMap();

            //Topic
            CreateMap<TopicWithPostsViewModel, TopicWithPostsDTO>().ReverseMap();
            CreateMap<PostViewModel, PostDTO>().ReverseMap();

            //Security
            CreateMap<RegistrationViewModel, RegistrationDTO>().ReverseMap();
            CreateMap<LogInViewModel, LogInDTO>().ReverseMap();

            //ControlPanel
            CreateMap<ProfileOverviewViewModel, ProfileDTO>().ReverseMap();
            CreateMap<UserMostActiveTopicViewModel, UserMostActiveTopicDTO>().ReverseMap();
            CreateMap<UserMostActiveCategoryViewModel, UserMostActiveCategoryDTO>().ReverseMap();
            CreateMap<ChangePasswordViewModel, ChangePasswordDTO>().ReverseMap();
            CreateMap<ChangeProfileViewModel, ProfileDTO>().ReverseMap();
            CreateMap<ChangeProfileViewModel, ChangeProfileDTO>().ReverseMap();
        }
    }
}