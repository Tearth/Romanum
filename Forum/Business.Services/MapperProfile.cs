using AutoMapper;
using Business.Services.DTO.Avatar;
using Business.Services.DTO.Profile;
using DataAccess.Entities;

namespace Business.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ChangeProfileDTO, User>().ReverseMap();
            CreateMap<AvatarDTO, Avatar>().ReverseMap();
            CreateMap<ChangedAvatarDTO, Avatar>().ReverseMap();
        }
    }
}
