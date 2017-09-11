using Business.Services.DTO.Profile;
using Business.Services.ProfileServices.Exceptions;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            var selectedUser = _databaseContext.Users
                .Include(user => user.Posts)
                .Include(user => user.Posts.Select(post => post.Topic))
                .Include(user => user.Posts.Select(post => post.Topic.Category))
                .FirstOrDefault(u => u.ID == id);

            if(selectedUser == null)
                throw new UserProfileNotFoundException();

            var userMostActiveTopic = selectedUser.Posts
                .GroupBy(post => post.Topic.ID)
                .OrderByDescending(post => post.Count())
                .First()
                .Select(post => new
                {
                    TopicName = post.Topic.Name,
                    TopicAlias = post.Topic.Alias,
                    CategoryAlias = post.Topic.Category.Alias
                }).First();

            var userMostActiveCategory = selectedUser.Posts
                .GroupBy(post => post.Topic.Category.ID)
                .OrderByDescending(post => post.Count())
                .First()
                .Select(post => new
                {
                    CategoryName = post.Topic.Category.Name,
                    CategoryAlias = post.Topic.Category.Alias
                }).First();

            var profile = new ProfileDTO()
            {
                JoinTime = selectedUser.JoinTime,

                PostsCount = selectedUser.Posts.Count(),
                PostsPerDay = selectedUser.Posts.Count() / (float)(DateTime.Now - selectedUser.JoinTime).TotalDays,
                PercentageOfAllPosts = (float)selectedUser.Posts.Count() / _databaseContext.Posts.Count(),

                MostActiveTopicName = userMostActiveTopic.TopicAlias,
                MostActiveTopicAlias = userMostActiveTopic.TopicAlias,
                MostActiveTopicCategoryAlias = userMostActiveTopic.CategoryAlias,

                MostActiveCategoryName = userMostActiveCategory.CategoryName,
                MostActiveCategoryAlias = userMostActiveCategory.CategoryAlias
            };

            return profile;
        }
    }
}
