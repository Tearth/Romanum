using System;

namespace Business.Services.DTO.Profile
{
    public class ProfileDTO
    {
        public string UserName { get; set; }
        public string EMail { get; set; }
        public DateTime JoinTime { get; set; }

        public string City { get; set; }
        public string About { get; set; }
        public string Footer { get; set; }

        public int PostsCount { get; set; }
        public float PostsPerDay { get; set; }
        public float PercentageOfAllPosts { get; set; }

        public UserMostActiveTopicDTO MostActiveTopic { get; set; }
        public UserMostActiveCategoryDTO MostActiveCategory { get; set; }
    }
}
