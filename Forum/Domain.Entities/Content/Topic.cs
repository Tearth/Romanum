using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Content
{
    public class Topic
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; private set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Topic(string name)
        {
            Name = name;
            CreateTime = DateTime.Now;
        }
    }
}
