using Business.Services.ProfileServices;
using Business.Services.ProfileServices.Exceptions;
using Business.Services.Tests.Helpers;
using DataAccess.Database;
using DataAccess.Entities.Content;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Services.Tests
{
    public class ProfileServiceTests
    {
        Mock<IDatabaseContext> GetDatabaseContextMock()
        {
            var users = new List<User>();
            var categories = new List<Category>();

            var firstUser = new User("User 1") { ID = 1, EMail = "user1@local.domain", JoinTime = new DateTime(2010, 5, 10) };
            var secondUser = new User("User 2") { ID = 2, EMail = "user2@local.domain", JoinTime = new DateTime(2013, 11, 26) };
            var thirdUser = new User("User 3") { ID = 3, EMail = "user3@local.domain", JoinTime = new DateTime(2011, 10, 16) };

            users.AddMany(firstUser, secondUser, thirdUser);

            var firstCategory = new Category("Category 1", "cat-1") { ID = 1 };
            var secondCategory = new Category("Category 2", "cat-2") { ID = 2 };
            var thirdCategory = new Category("Category 3", "cat-3") { ID = 3 };

            categories.AddMany(firstCategory, secondCategory, thirdCategory);

            var firstTopic = new Topic("Topic 1", "top-1") { ID = 1, Category = firstCategory };
            var secondTopic = new Topic("Topic 2", "top-2") { ID = 2, Category = firstCategory };
            var thirdTopic = new Topic("Topic 3", "top-3") { ID = 3, Category = secondCategory };

            firstCategory.Topics.AddMany(firstTopic, secondTopic);
            secondCategory.Topics.AddMany(thirdTopic);

            var firstPost = new Post("Content 1", new DateTime(2000, 5, 10)) { ID = 1, Topic = firstTopic, Author = firstUser };
            var secondPost = new Post("Content 2", new DateTime(2001, 1, 2)) { ID = 2, Topic = firstTopic, Author = firstUser };
            var thirdPost = new Post("Content 3", new DateTime(2002, 10, 12)) { ID = 3, Topic = firstTopic, Author = firstUser };
            var fourthPost = new Post("Content 4", new DateTime(2003, 3, 27)) { ID = 4, Topic = secondTopic, Author = secondUser };
            var fifthPost = new Post("Content 5", new DateTime(2004, 2, 1)) { ID = 5, Topic = thirdTopic, Author = secondUser };

            firstTopic.Posts.AddMany(firstPost, secondPost, thirdPost);
            secondTopic.Posts.AddMany(fourthPost);
            thirdTopic.Posts.AddMany(fifthPost);

            firstUser.Posts.AddMany(firstPost, secondPost, thirdPost);
            secondUser.Posts.AddMany(fourthPost, fifthPost);

            var topicsList = categories.SelectMany(p => p.Topics);
            var postsList = topicsList.SelectMany(p => p.Posts);

            var usersFakeDbSet = FakeDbSetFactory.Creation<User>(users);
            var categoriesFakeDbSet = FakeDbSetFactory.Creation<Category>(categories);
            var topicsFakeDbSet = FakeDbSetFactory.Creation<Topic>(topicsList);
            var postsFakeDbSet = FakeDbSetFactory.Creation<Post>(postsList);

            var fakeDatabaseContext = new Mock<IDatabaseContext>();
            fakeDatabaseContext.Setup(p => p.Users).Returns(usersFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Categories).Returns(categoriesFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Topics).Returns(topicsFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Posts).Returns(postsFakeDbSet.Object);

            return fakeDatabaseContext;
        }

        [Theory]
        [InlineData("User 1")]
        [InlineData("User 2")]
        public void UserNameExists_ExistingUserName_ReturnsTrue(string userName)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var result = profileService.UserNameExists(userName);

            Assert.True(result);
        }

        [Fact]
        public void UserNameExists_NotExistingUserName_ReturnsFalse()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var result = profileService.UserNameExists("Not existing user name");

            Assert.False(result);
        }

        [Theory]
        [InlineData("user1@local.domain")]
        [InlineData("user2@local.domain")]
        public void EMailExists_ExistingEMail_ReturnsTrue(string email)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var result = profileService.EMailExists(email);

            Assert.True(result);
        }

        [Fact]
        public void EMailExists_NotExistingEmail_ReturnsFalse()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var result = profileService.EMailExists("invalid@local.domain");

            Assert.False(result);
        }

        [Theory]
        [InlineData(1, 3, 0.6f)]
        [InlineData(2, 2, 0.4f)]
        public void GetProfileByUserID_ExistingID_ReturnsValidPostsData(int userID, int expectedPostsCount, float expectedPercentageOfAllPosts)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var result = profileService.GetProfileByUserID(userID);
            
            Assert.Equal(expectedPostsCount, result.PostsCount);
            Assert.Equal(expectedPercentageOfAllPosts, result.PercentageOfAllPosts, 1);
        }

        [Theory]
        [InlineData(1, "Category 1", "cat-1")]
        [InlineData(2, "Category 1", "cat-1")]
        [InlineData(3, null, null)]
        public void GetProfileByUserID_ExistingID_ReturnsValidMostActiveCategory(int userID, string expectedCategoryName, string expectedCategoryAlias)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var result = profileService.GetProfileByUserID(userID);

            Assert.Equal(expectedCategoryName, result.MostActiveCategory.CategoryName);
            Assert.Equal(expectedCategoryAlias, result.MostActiveCategory.CategoryAlias);
        }
        
        [Theory]
        [InlineData(1, "Topic 1", "top-1", "cat-1")]
        [InlineData(2, "Topic 2", "top-2", "cat-1")]
        [InlineData(3, null, null)]
        public void GetProfileByUserID_ExistingID_ReturnsValidMostActiveTopic(int userID, string expectedTopicName, string expectedTopicAlias, string expectedTopicCategoryAlias)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var result = profileService.GetProfileByUserID(userID);

            Assert.Equal(expectedTopicName, result.MostActiveTopic.TopicName);
            Assert.Equal(expectedTopicAlias, result.MostActiveTopic.TopicAlias);
            Assert.Equal(expectedTopicCategoryAlias, result.MostActiveTopic.TopicCategoryAlias);
        }

        [Fact]
        public void GetProfileByUserID_NotExistingID_ThrowsUserProfileNotFoundException()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var profileService = new ProfileService(databaseContextMock.Object);
            var exception = Record.Exception(() => profileService.GetProfileByUserID(1001));

            Assert.IsType<UserProfileNotFoundException>(exception);
        }
    }
}
