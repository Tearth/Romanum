using System.Collections.Generic;
using DataAccess.Entities.Enums;

namespace DataAccess.Entities
{
    public class Avatar : EntityBase
    {
        public AvatarType Type { get; set; }
        public string Source { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Avatar()
        {
            Users = new List<User>();
        }
    }
}
