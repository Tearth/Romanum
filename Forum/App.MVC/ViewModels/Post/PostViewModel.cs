using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Post
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Content { get; set; }
    }
}