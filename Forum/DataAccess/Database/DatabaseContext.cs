using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Database
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public virtual IDbSet<Section> Sections { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Topic> Topics { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Avatar> Avatars { get; set; }
        public virtual IDbSet<Config> Configuration { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(string connectionStringName) : base(connectionStringName)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
