using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Database.MapConfig
{
    internal class PostEntityConfig : EntityTypeConfiguration<Post>
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
