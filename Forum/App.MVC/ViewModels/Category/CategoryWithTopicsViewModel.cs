using System.Collections.Generic;

namespace App.MVC.ViewModels.Category
{
    public class CategoryWithTopicsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public IEnumerable<TopicDetailsViewModel> Topics { get; set; }
    }
}