﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Section
{
    public class SectionWithCategoriesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryDetalisViewModel> Categories { get; set; }
    }
}