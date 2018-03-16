using System.Collections.Generic;

namespace Business.Services.DTO.Section
{
    /// <summary>
    /// Represents the section information with the associated categories.
    /// </summary>
    public class SectionWithCategoriesDTO
    {
        /// <summary>
        /// Gets or sets the section ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the section name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of categories which are stored in the section.
        /// </summary>
        public IEnumerable<CategoryDetailsDTO> Categories { get; set; }
    }
}
