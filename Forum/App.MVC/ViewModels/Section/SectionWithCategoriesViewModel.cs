using System.Collections.Generic;

namespace App.MVC.ViewModels.Section
{
    public class SectionWithCategoriesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryDetailsViewModel> Categories { get; set; }
    }
}