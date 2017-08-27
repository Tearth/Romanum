using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class Post : EntityBase
    {
        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }
        public string Content { get; private set; }

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

        public void SetContent(string content)
        {
            Content = content;
            ModifyTime = DateTime.Now;
        }
    }
}
