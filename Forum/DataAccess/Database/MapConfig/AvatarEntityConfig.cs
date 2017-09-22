using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig
{
    public class AvatarEntityConfig : EntityTypeConfiguration<Avatar>
    {
        public AvatarEntityConfig()
        {
            Property(p => p.Type).IsRequired();
            Property(p => p.Source).HasMaxLength(256);

            HasRequired(p => p.User);
        }
    }
}
