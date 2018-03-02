using System.Collections.Generic;

namespace Business.Services.DTO.Section
{
    public class SectionWithCategoriesDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryDetailsDTO> Categories { get; set; }
    }
}
