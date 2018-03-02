using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Database.MapConfig
{
    internal class CategoryEntityConfig : EntityTypeConfiguration<Category>
    {
        public CategoryEntityConfig()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Alias).HasMaxLength(50).IsRequired();
            Property(p => p.Description).HasMaxLength(200);
            Property(p => p.Order).IsRequired();

            HasRequired(category => category.Section)
                .WithMany(section => section.Categories)
                .HasForeignKey(category => category.SectionID)
                .WillCascadeOnDelete(false);

            HasMany(category => category.Topics)
                .WithRequired(topic => topic.Category)
                .HasForeignKey(topic => topic.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
