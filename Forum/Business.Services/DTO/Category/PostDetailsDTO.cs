using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.DTO.Category
{
    public class PostDetailsDTO
    {
        public String Name { get; set; }
        public String Alias { get; set; }
        public String AuthorName { get; set; }
        public int UniqueNumber { get; set; }
        public DateTime CreateTime { get; set; }
        public String LastPostAuthorName { get; set; }
        public DateTime LastPostTime { get; set; }
    }
}
