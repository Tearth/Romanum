using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Category
{
    public class CategoryWithTopicsViewModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Alias { get; set; }
        public IEnumerable<TopicDetailsViewModel> Topics { get; set; }
    }
}