﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DTOs
{
    public class SectionWithCategoriesDTO
    {
        public string Name { get; set; }
        public IEnumerable<CategoryDetailsDTO> Categories { get; set; }
    }
}