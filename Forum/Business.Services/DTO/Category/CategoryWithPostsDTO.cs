using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
