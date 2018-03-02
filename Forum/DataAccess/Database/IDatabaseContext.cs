using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Database
{
    public interface IDatabaseContext
    {
        IDbSet<Section> Sections { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Topic> Topics { get; set; }
        IDbSet<Post> Posts { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<Avatar> Avatars { get; set; }
        IDbSet<Config> Configs { get; set; }

        int SaveChanges();
    }
}
