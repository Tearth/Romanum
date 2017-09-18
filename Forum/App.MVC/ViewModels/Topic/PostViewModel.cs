﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.Topic
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public string Content { get; set; }

        public string AuthorName { get; set; }
        public int AuthorPostsCount { get; set; }
        public DateTime AuthorJoinTime { get; set; }
        public string AuthorCity { get; set; }
        public string AuthorFooter { get; set; }
    }
}