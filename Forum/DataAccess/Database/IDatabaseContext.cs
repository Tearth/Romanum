using DataAccess.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database
{
    public interface IDatabaseContext
    {
        IDbSet<Section> Sections { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Topic> Topics { get; set; }
        IDbSet<Post> Posts { get; set; }
        IDbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
