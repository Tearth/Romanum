﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class Section : EntityBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public Section(string name, string alias)
        {
            Name = name;
            Alias = alias;
        }
    }
}