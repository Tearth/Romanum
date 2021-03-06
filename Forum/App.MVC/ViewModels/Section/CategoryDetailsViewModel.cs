﻿using System;

namespace App.MVC.ViewModels.Section
{
    public class CategoryDetailsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int TopicsCount { get; set; }
        public int PostsCount { get; set; }
        public DateTime LastPostCreationTime { get; set; }
    }
}