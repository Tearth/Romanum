using System;

namespace DataAccess.Entities
{
    public class Post : EntityBase
    {
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public string Content { get; set; }

        public int TopicID { get; set; }
        public virtual Topic Topic { get; set; }

        public int AuthorID { get; set; }
        public virtual User Author { get; set; }
    }
}
