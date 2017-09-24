using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig
{
    class CategoryEntityConfig : EntityTypeConfiguration<Category>
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
