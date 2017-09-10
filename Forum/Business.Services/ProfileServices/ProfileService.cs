using Business.Services.DTO.Profile;
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
            var profile = _databaseContext
                .Users.Where(user => user.ID == id)
                .Select(user => new ProfileDTO()
                {
                    JoinTime = user.JoinTime,

                    PostsCount = user.Posts.Count(),
                    PostsPerDay = user.Posts.Count() / (float)(DateTime.Now - user.JoinTime).TotalDays,
                    PercentageOfAllPosts = (float)user.Posts.Count() / _databaseContext.Posts.Count(),

                    MostActiveTopicName = user.Posts.Select(post => post.Topic).Max(topic => topic.Name),
                    MostActiveTopicAlias = user.Posts.Select(post => post.Topic).Max(topic => topic.Alias),
                    MostActiveTopicCategory = user.Posts.Select(post => post.Topic).Max(topic => topic.Category.Alias),

                    MostActiveCategoryName = user.Posts.Select(post => post.Topic).Select(topic => topic.Category)
                                                                                  .Max(category => category.Name),
                    MostActiveCategoryAlias = user.Posts.Select(post => post.Topic).Select(topic => topic.Category)
                                                                                   .Max(category => category.Alias)
                }).Single();

            return profile;
        }
    }
}
