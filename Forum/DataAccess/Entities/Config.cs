﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Config : EntityBase
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Config()
        {

        }
    }
}