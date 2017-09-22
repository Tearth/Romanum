using DataAccess.Entities;
using DataAccess.Entities;
using DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DatabaseContext() : base()
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
