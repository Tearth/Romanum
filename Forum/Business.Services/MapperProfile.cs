using AutoMapper;
using Business.Services.DTO.Profile;
using Business.Services.DTO.Section;
using DataAccess.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ChangeProfileDTO, User>();
        }
    }
}
