using System.Collections.Generic;

namespace Business.Services.DTO.Category
{
    public class CategoryWithPostsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int Order { get; set; }
        public IEnumerable<TopicDetailsDTO> Topics { get; set; }
    }
}
