using DataAccess.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig.Content
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            Property(p => p.Name).HasMaxLength(20).IsRequired();
            Property(p => p.EMail).HasMaxLength(100).IsRequired();
            Property(p => p.JoinTime).IsRequired();
        }
    }
}
