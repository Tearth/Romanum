using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Database.MapConfig
{
    internal class TopicEntityConfig : EntityTypeConfiguration<Topic>
    {
        public TopicEntityConfig()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Alias).HasMaxLength(100).IsRequired();

            HasRequired(topic => topic.Category)
                .WithMany(category => category.Topics)
                .HasForeignKey(topic => topic.CategoryID)
                .WillCascadeOnDelete(false);

            HasMany(topic => topic.Posts)
                .WithRequired(post => post.Topic)
                .HasForeignKey(post => post.TopicID)
                .WillCascadeOnDelete(false);
        }
    }
}
