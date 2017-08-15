using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Content
{
    public class Post : EntityBase
    {
        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }
        private string Content { get; private set; }

        public virtual Topic Topic { get; set; }

        public Post(string content)
        {
            Content = content;

            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
        }

        public void SetContent(string content)
        {
            Content = content;
            ModifyTime = DateTime.Now;
        }
    }
}
