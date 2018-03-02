using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Database.MapConfig
{
    internal class SectionEntityConfig : EntityTypeConfiguration<Section>
    {
        public SectionEntityConfig()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Alias).HasMaxLength(50).IsRequired();
            Property(p => p.Description).HasMaxLength(200);
            Property(p => p.Order).IsRequired();

            HasMany(section => section.Categories)
                .WithRequired(category => category.Section)
                .HasForeignKey(category => category.SectionID)
                .WillCascadeOnDelete(false);
        }
    }
}
