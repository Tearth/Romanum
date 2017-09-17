using Business.Services.DTO.Profile;
using Business.Services.ProfileServices.Exceptions;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Entities.Content;
using Business.Services.Helpers.Time;
using AutoMapper;

namespace Business.Services.ProfileServices
{
    public class ProfileService : ServiceBase, IProfileService
    {
        IDatabaseContext _databaseContext;
        ITimeProvider _timeProvider;

        public ProfileService(IDatabaseContext databaseContext, ITimeProvider timeProvider)
        {
            _databaseContext = databaseContext;
            _timeProvider = timeProvider;
        }

        public bool UserNameExists(string name)
        {
            return _databaseContext.Users.Any(user => user.Name == name);
        }

        public bool EMailExists(string email)
        {
            return _databaseContext.Users.Any(user => user.EMail == email);
        }

        public bool ProfileExists(int id)
        {
            return _databaseContext.Users.Any(user => user.ID == id);
        }

        public void ChangeProfile(int id, ChangeProfileDTO profileData)
        {
            if (!ProfileExists(id))
                throw new UserProfileNotFoundException();

            var profile = _databaseContext.Users.First(user => user.ID == id);

            if (profile.EMail != profileData.EMail && EMailExists(profileData.EMail))
                throw new EMailAlreadyExistsException();

            profile = Mapper.Map<ChangeProfileDTO, User>(profileData, profile);

            _databaseContext.SaveChanges();
        }

        public ProfileDTO GetProfileByUserID(int id)
        {
            if (!ProfileExists(id))
                throw new UserProfileNotFoundException();

            var profileQuery = _databaseContext.Users.Where(user => user.ID == id);
            var dateTimeNow = _timeProvider.Now();
            
            var profile = profileQuery.Select(user => new ProfileDTO()
            {
                UserName = user.Name,
                EMail = user.EMail,
                JoinTime = user.JoinTime,

                City = user.City,
                About = user.About,
                Footer = user.Footer,

                PostsCount = user.Posts.Count(),
                PostsPerDay = user.Posts.Count() / (float)DbFunctions.DiffDays(user.JoinTime, dateTimeNow),
                PercentageOfAllPosts = (float)user.Posts.Count() / _databaseContext.Posts.Count(),

                MostActiveTopic = user.Posts
                    .GroupBy(post => post.Topic.ID)
                    .OrderByDescending(post => post.Count())
                    .FirstOrDefault()
                    .Select(post => new UserMostActiveTopicDTO()
                    {
                        TopicName = post.Topic.Name,
                        TopicAlias = post.Topic.Alias,
                        TopicCategoryAlias = post.Topic.Category.Alias
                    }).FirstOrDefault(),

                MostActiveCategory = user.Posts
                    .GroupBy(post => post.Topic.Category.ID)
                    .OrderByDescending(post => post.Count())
                    .FirstOrDefault()
                    .Select(post => new UserMostActiveCategoryDTO()
                    {
                        CategoryName = post.Topic.Category.Name,
                        CategoryAlias = post.Topic.Category.Alias
                    }).FirstOrDefault()
            }).Single();

            return profile;
        }
    }
}
