﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public abstract class EntityBase
    {
        public int ID { get; protected set; }
    }
}