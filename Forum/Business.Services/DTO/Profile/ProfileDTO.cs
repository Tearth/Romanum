using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DTO.Profile
{
    public class ProfileDTO
    {
        public DateTime JoinTime { get; set; }

        public int PostsCount { get; set; }
        public float PostsPerDay { get; set; }
        public float PercentageOfAllPosts { get; set; }

        public UserMostActiveTopicDTO MostActiveTopic { get; set; }
        public UserMostActiveCategoryDTO MostActiveCategory { get; set; }
    }
}
