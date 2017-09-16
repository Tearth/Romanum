﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DTO.Section
{
    public class CategoryDetailsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public int TopicsCount { get; set; }
        public int PostsCount { get; set; }
        public DateTime LastPostCreationTime { get; set; }
    }
}
