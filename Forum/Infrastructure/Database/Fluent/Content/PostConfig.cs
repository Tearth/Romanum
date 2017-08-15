using Domain.Entities;
using Domain.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Fluent.Content
{
    class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            Property(p => p.Content).HasMaxLength(1000);
            Property(p => p.CreateTime).IsRequired();
            Property(p => p.ModifyTime).IsRequired();
        }
    }
}
