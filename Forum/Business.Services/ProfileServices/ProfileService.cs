using Business.Services.DTO.Profile;
using Business.Services.ProfileServices.Exceptions;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProfileServices
{
    public class ProfileService : ServiceBase, IProfileService
    {
        IDatabaseContext _databaseContext;

        public ProfileService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool UserNameExists(string name)
        {
            return _databaseContext.Users.Any(user => user.Name == name);
        }

        public bool EMailExists(string email)
        {
            return _databaseContext.Users.Any(user => user.EMail == email);
        }

        public ProfileDTO GetProfileByUserID(int id)
        {
            if (!_databaseContext.Users.Any(user => user.ID == id))
                throw new UserProfileNotFoundException();

            var profile = _databaseContext
                .Users.Where(user => user.ID == id)
                .Select(user => new ProfileDTO()
                {
                    JoinTime = user.JoinTime,

                    PostsCount = user.Posts.Count(),
                    PostsPerDay = user.Posts.Count() / (float)(DateTime.Now - user.JoinTime).TotalDays,
                    PercentageOfAllPosts = (float)user.Posts.Count() / _databaseContext.Posts.Count(),

                    MostActiveTopicName = user.Posts.GroupBy(post => post.Topic.ID)
                                                    .OrderByDescending(post => post.Count())
                                                    .SelectMany(p => p, (group, post) => post)
                                                    .First().Topic.Name,

                    MostActiveTopicAlias = user.Posts.GroupBy(post => post.Topic.ID)
                                                    .OrderByDescending(post => post.Count())
                                                    .SelectMany(p => p, (group, post) => post)
                                                    .First().Topic.Alias,

                    MostActiveTopicCategoryAlias = user.Posts.GroupBy(post => post.Topic.ID)
                                                    .OrderByDescending(post => post.Count())
                                                    .SelectMany(p => p, (group, post) => post)
                                                    .First().Topic.Category.Alias,

                    MostActiveCategoryName = user.Posts.GroupBy(post => post.Topic.Category.ID)
                                                    .OrderByDescending(post => post.Count())
                                                    .SelectMany(p => p, (group, post) => post.Topic.Category)
                                                    .First().Name,

                    MostActiveCategoryAlias = user.Posts.GroupBy(post => post.Topic.ID)
                                                    .OrderByDescending(post => post.Count())
                                                    .SelectMany(p => p, (group, post) => post.Topic.Category)
                                                    .First().Alias
                }).Single();

            return profile;
        }
    }
}
