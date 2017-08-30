using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class Topic : EntityBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Topic(string name) : this(name, DateTime.Now)
        {

        }

        public Topic(string name, DateTime createTime)
        {
            Name = name;
            CreateTime = createTime;
        }
    }
}
