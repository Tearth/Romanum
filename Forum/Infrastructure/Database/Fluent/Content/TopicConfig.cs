using Domain.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Fluent.Content
{
    class TopicConfig : EntityTypeConfiguration<Topic>
    {
        public TopicConfig()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.CreateTime).IsRequired();
        }
    }
}
