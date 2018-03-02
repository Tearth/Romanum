using System.Collections.Generic;

namespace Business.Services.DTO.Topic
{
    public class TopicWithPostsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
