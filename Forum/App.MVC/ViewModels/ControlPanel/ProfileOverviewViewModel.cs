using System;

namespace App.MVC.ViewModels.ControlPanel
{
    public class ProfileOverviewViewModel
    {
        public DateTime JoinTime { get; set; }

        public int PostsCount { get; set; }
        public float PostsPerDay { get; set; }
        public float PercentageOfAllPosts { get; set; }

        public UserMostActiveTopicViewModel MostActiveTopic { get; set; }
        public UserMostActiveCategoryViewModel MostActiveCategory { get; set; }
    }
}
