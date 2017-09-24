using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Section : EntityBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public Section()
        {
            Categories = new List<Category>();
        }
    }
}
