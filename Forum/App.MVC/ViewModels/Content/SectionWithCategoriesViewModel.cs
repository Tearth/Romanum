using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Content
{
    public class SectionWithCategoriesViewModel
    {
        public string Name { get; set; }
        public IEnumerable<CategoryDetalisViewModel> Categories { get; set; }
    }
}