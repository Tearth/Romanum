using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }

        public Category()
        {

        }

        public Category(string name, string alias)
        {
            Name = name;
            Alias = alias;

            Topics = new List<Topic>();
        }
    }
}
