using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Fluent
{
    class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {

        }
    }
}
