﻿using System.Collections.Generic;

namespace App.MVC.ViewModels.Topic
{
    public class TopicWithPostsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}