using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig
{
    //"Name of this class is strange, sorry" - naming convention
    class ConfigEntityConfig : EntityTypeConfiguration<Config>
    {
        public ConfigEntityConfig()
        {
            Property(p => p.Key).IsRequired();
        }
    }
}