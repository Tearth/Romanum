using DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
