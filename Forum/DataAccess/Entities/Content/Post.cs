using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class Post : EntityBase
    {
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public string Content { get; set; }

        public virtual Topic Topic { get; set; }

        public Post(string content) : this(content, DateTime.Now)
        {
            
        }

        public Post(string content, DateTime creationTime)
        {
            Content = content;

            CreationTime = creationTime;
            ModificationTime = creationTime;
        }
    }
}
