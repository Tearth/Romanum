using Business.Services.DTO.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DTO.Topic
{
    public class TopicDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int UniqueNumber { get; set; }

        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
