using DataAccess.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig.Content
{
    class TopicEntityConfig : EntityTypeConfiguration<Topic>
    {
        public TopicEntityConfig()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Alias).HasMaxLength(100).IsRequired();

            HasRequired(p => p.Category);
        }
    }
}
