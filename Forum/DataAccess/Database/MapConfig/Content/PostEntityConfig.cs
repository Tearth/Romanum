using DataAccess.Entities;
using DataAccess.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig.Content
{
    class PostEntityConfig : EntityTypeConfiguration<Post>
    {
        public PostEntityConfig()
        {
            Property(p => p.Content).HasMaxLength(1000);
            Property(p => p.CreationTime).IsRequired();
            Property(p => p.ModificationTime).IsRequired();

            HasRequired(p => p.Topic);
            HasRequired(p => p.Author);
        }
    }
}
