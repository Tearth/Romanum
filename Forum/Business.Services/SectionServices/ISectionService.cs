using Business.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.SectionServices
{
    public interface ISectionService
    {
        IEnumerable<SectionWithCategoriesDTO> GetAllSetionsWithCategories();
    }
}
