using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Database.MapConfig
{
    //"Name of this class is strange, sorry" - naming convention
    internal class ConfigEntityConfig : EntityTypeConfiguration<Config>
    {
        public ConfigEntityConfig()
        {
            Property(p => p.Key).IsRequired();
        }
    }
}