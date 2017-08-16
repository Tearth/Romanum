using App.Services.ViewModels;
using AutoMapper;
using Domain.Services.SectionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.SectionService
{
    public class SectionAppService : ServiceBase, ISectionAppService
    {
        ISectionService _sectionService;

        public SectionAppService(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public IEnumerable<SectionWithCategoriesViewModel> GetAllSectionsWithDetails()
        {
            return Mapper.Map<IEnumerable<SectionWithCategoriesViewModel>>(_sectionService.GetAllSetionsWithCategories());
        }
    }
}
