﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Content
{
    public class Topic : EntityBase
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; private set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Topic(string name)
        {
            Name = name;
            CreateTime = DateTime.Now;
        }
    }
}