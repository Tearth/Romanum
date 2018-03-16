using System.Collections.Generic;
using Business.Services.DTO.Section;

namespace Business.Services.SectionServices
{
    /// <summary>
    /// Represents an interface for section service.
    /// </summary>
    public interface ISectionService
    {
        /// <summary>
        /// Gets the list of sections with associated categories.
        /// </summary>
        /// <returns>The list of sections with associated categories.</returns>
        IEnumerable<SectionWithCategoriesDTO> GetAllSectionsWithCategories();
    }
}
