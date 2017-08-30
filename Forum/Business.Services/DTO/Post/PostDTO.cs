using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DTO.Post
{
    public class PostDTO
    {
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Content { get; set; }
    }
}
