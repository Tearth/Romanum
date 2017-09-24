using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public DateTime JoinTime { get; set; }

        public string City { get; set; }
        public string About { get; set; }
        public string Footer { get; set; }

        public int AvatarID { get; set; }
        public virtual Avatar Avatar { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new List<Post>();
        }
    }
}
