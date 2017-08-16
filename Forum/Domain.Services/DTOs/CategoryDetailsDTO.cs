using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTOs
{
    public class CategoryDetailsDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TopicsCount { get; set; }
        public int PostsCount { get; set; }
        public DateTime LastPostTime { get; set; }
    }
}
