using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Category
{
    public class TopicDetailsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastPostAuthorName { get; set; }
        public DateTime LastPostCreationTime { get; set; }
        public int PostsCount { get; set; }
    }
}