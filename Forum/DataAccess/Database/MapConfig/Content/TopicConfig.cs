﻿using DataAccess.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.MapConfig.Content
{
    class TopicConfig : EntityTypeConfiguration<Topic>
    {
        public TopicConfig()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.CreateTime).IsRequired();

            HasRequired(p => p.Category);
        }
    }
}