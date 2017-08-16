using App.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.ViewModels
{
    public class SectionWithCategoriesViewModel
    {
        public string Name { get; set; }
        public IEnumerable<CategoryDetalisViewModel> Categories { get; set; }
    }
}
