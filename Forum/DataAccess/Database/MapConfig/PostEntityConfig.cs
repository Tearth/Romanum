using DataAccess.Entities;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig
{
    class PostEntityConfig : EntityTypeConfiguration<Post>
    {
        public PostEntityConfig()
        {
            Property(p => p.Content).HasMaxLength(1000);
            Property(p => p.CreationTime).IsRequired();
            Property(p => p.ModificationTime).IsRequired();

            HasRequired(post => post.Topic)
                .WithMany(topic => topic.Posts)
                .HasForeignKey(post => post.TopicID)
                .WillCascadeOnDelete(false);

            HasRequired(post => post.Author)
                .WithMany(author => author.Posts)
                .HasForeignKey(post => post.AuthorID)
                .WillCascadeOnDelete(false);
        }
    }
}
