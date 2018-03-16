using System;

namespace Business.Services.DTO.Profile
{
    /// <summary>
    /// Represents the profile information.
    /// </summary>
    public class ProfileDTO
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user e-mail.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets the user join date.
        /// </summary>
        public DateTime JoinTime { get; set; }

        /// <summary>
        /// Gets or sets the user city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the additional user information.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Gets or sets the footer (displayed at end of the each user post).
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// Gets or sets the total posts count.
        /// </summary>
        public int PostsCount { get; set; }

        /// <summary>
        /// Gets or sets the posts per day count.
        /// </summary>
        public float PostsPerDay { get; set; }

        /// <summary>
        /// Gets or sets the percentage of all posts count.
        /// </summary>
        public float PercentageOfAllPosts { get; set; }

        /// <summary>
        /// Gets the most active topic which the user was participating.
        /// </summary>
        public UserMostActiveTopicDTO MostActiveTopic { get; set; }

        /// <summary>
        /// Gets the most active category which the user was participating.
        /// </summary>
        public UserMostActiveCategoryDTO MostActiveCategory { get; set; }
    }
}
