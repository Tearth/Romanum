using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public int SectionID { get; set; }
        public virtual Section Section { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public Category()
        {
            Topics = new List<Topic>();
        }
    }
}
