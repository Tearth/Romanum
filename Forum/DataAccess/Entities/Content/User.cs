using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public DateTime JoinTime { get; set; }

        public string City { get; set; }
        public string About { get; set; }
        public string Footer { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {

        }

        public User(string userName)
        {
            Name = userName;

            Posts = new List<Post>();
        }
    }
}
