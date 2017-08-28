using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.Category
{
    public class CategoryWithPostsDTO
    {
        public String Name { get; set; }
        public String Alias { get; set; }
        public IEnumerable<TopicDetailsDTO> Topics { get; set; }
    }
}
