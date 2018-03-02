using System.Collections.Generic;
using Business.Services.DTO.Section;

namespace Business.Services.SectionServices
{
    public interface ISectionService
    {
        IEnumerable<SectionWithCategoriesDTO> GetAllSetionsWithCategories();
    }
}
