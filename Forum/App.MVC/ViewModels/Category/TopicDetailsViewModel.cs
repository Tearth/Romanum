using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Category
{
    public class TopicDetailsViewModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Alias { get; set; }
        public String AuthorName { get; set; }
        public DateTime CreateTime { get; set; }
        public String LastPostAuthorName { get; set; }
        public DateTime LastPostTime { get; set; }
        public int PostsCount { get; set; }
    }
}