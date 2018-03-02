using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Database.MapConfig
{
    public class AvatarEntityConfig : EntityTypeConfiguration<Avatar>
    {
        public AvatarEntityConfig()
        {
            Property(p => p.Type).IsRequired();
            Property(p => p.Source).HasMaxLength(256);

            HasMany(avatar => avatar.Users)
                .WithOptional(user => user.Avatar)
                .HasForeignKey(user => user.AvatarID)
                .WillCascadeOnDelete(false);
        }
    }
}
