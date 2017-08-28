using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Category
{
    public class CategoryWithPostsViewModel
    {
        public String Name { get; set; }
        public String Alias { get; set; }
        public IEnumerable<TopicDetailsViewModel> Topics { get; set; }
    }
}