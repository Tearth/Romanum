using Domain.Entities;
using Domain.Entities.Content;
using Domain.Services.Database;
using Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public virtual IDbSet<Section> Sections { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }

        public DatabaseContext() : base("MainDB")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
