using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DTO.Category
{
    public class TopicDetailsDTO
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Alias { get; set; }
        public FeaturedPostDTO FirstPost { get; set; }
        public FeaturedPostDTO LastPost { get; set; }
        public int PostsCount { get; set; }
    }
}
