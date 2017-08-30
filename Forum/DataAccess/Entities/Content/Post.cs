using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class Post : EntityBase
    {
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Content { get; set; }

        public virtual Topic Topic { get; set; }

        public Post(string content) : this(content, DateTime.Now)
        {
            
        }

        public Post(string content, DateTime createTime)
        {
            Content = content;

            CreateTime = createTime;
            ModifyTime = createTime;
        }
    }
}
