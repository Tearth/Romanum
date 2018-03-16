using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Business.Services.DTO.Profile;
using Business.Services.Helpers.Time;
using Business.Services.ProfileServices.Exceptions;
using DataAccess.Database;

namespace Business.Services.ProfileServices
{
    /// <summary>
    /// Represents a set of methods to manage profiles.
    /// </summary>
    public class ProfileService : ServiceBase, IProfileService
    {
        private IDatabaseContext _databaseContext;
        private ITimeProvider _timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileService"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        /// <param name="timeProvider">The time provider.</param>
        public ProfileService(IDatabaseContext databaseContext, ITimeProvider timeProvider)
        {
            _databaseContext = databaseContext;
            _timeProvider = timeProvider;
        }

        /// <inheritdoc />
        public bool UserNameExists(string name)
        {
            return _databaseContext.Users.Any(user => user.Name == name);
        }

        /// <inheritdoc />
        public bool EMailExists(string email)
        {
            return _databaseContext.Users.Any(user => user.EMail == email);
        }

        /// <inheritdoc />
        public bool ProfileExists(int id)
        {
            return _databaseContext.Users.Any(user => user.ID == id);
        }

        /// <inheritdoc />
        public void ChangeProfile(int id, ChangeProfileDTO newProfileData)
        {
            if (!ProfileExists(id))
            {
                throw new UserProfileNotFoundException();
            }

            var currentProfile = _databaseContext.Users.First(user => user.ID == id);

            if (currentProfile.EMail != newProfileData.EMail && EMailExists(newProfileData.EMail))
            {
                throw new EMailAlreadyExistsException();
            }

            currentProfile = Mapper.Map(newProfileData, currentProfile);

            _databaseContext.SaveChanges();
        }

        /// <inheritdoc />
        public ProfileDTO GetProfileByUserID(int id)
        {
            if (!ProfileExists(id))
            {
                throw new UserProfileNotFoundException();
            }

            var profileQuery = _databaseContext.Users.Where(user => user.ID == id);
            var dateTimeNow = _timeProvider.Now();

            var profile = profileQuery.Select(user => new ProfileDTO
            {
                UserName = user.Name,
                EMail = user.EMail,
                JoinTime = user.JoinTime,

                City = user.City,
                About = user.About,
                Footer = user.Footer,

                PostsCount = user.Posts.Count,

                PostsPerDay = DbFunctions.DiffDays(user.JoinTime, dateTimeNow) == 0 ?
                    0 : user.Posts.Count / (float)DbFunctions.DiffDays(user.JoinTime, dateTimeNow),

                PercentageOfAllPosts = !_databaseContext.Posts.Any() ?
                    0 : (float)user.Posts.Count / _databaseContext.Posts.Count(),

                MostActiveTopic = user.Posts
                    .GroupBy(post => post.Topic.ID)
                    .OrderByDescending(post => post.Count())
                    .FirstOrDefault()
                    .Select(post => new UserMostActiveTopicDTO
                    {
                        TopicName = post.Topic.Name,
                        TopicAlias = post.Topic.Alias,
                        TopicCategoryAlias = post.Topic.Category.Alias
                    }).FirstOrDefault(),

                MostActiveCategory = user.Posts
                    .GroupBy(post => post.Topic.Category.ID)
                    .OrderByDescending(post => post.Count())
                    .FirstOrDefault()
                    .Select(post => new UserMostActiveCategoryDTO
                    {
                        CategoryName = post.Topic.Category.Name,
                        CategoryAlias = post.Topic.Category.Alias
                    }).FirstOrDefault()
            }).Single();

            return profile;
        }
    }
}
