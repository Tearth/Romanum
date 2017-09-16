using Business.Services.Helpers.Time;
using Business.Services.ProfileServices;
using Business.Services.ProfileServices.Exceptions;
using Business.Services.Tests.Helpers;
using Business.Services.Tests.Helpers.Database;
using DataAccess.Database;
using DataAccess.Entities.Content;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using Xunit.Sdk;

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    public class ProfileServiceTests
    {
        [Theory]
        [InlineData("User 1")]
        [InlineData("User 2")]
        public void UserNameExists_ExistingUserName_ReturnsTrue(string userName)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var result = profileService.UserNameExists(userName);

            Assert.True(result);
        }

        [Fact]
        public void UserNameExists_NotExistingUserName_ReturnsFalse()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var result = profileService.UserNameExists("Not existing user name");

            Assert.False(result);
        }

        [Theory]
        [InlineData("user1@local.domain")]
        [InlineData("user2@local.domain")]
        public void EMailExists_ExistingEMail_ReturnsTrue(string email)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var result = profileService.EMailExists(email);

            Assert.True(result);
        }

        [Fact]
        public void EMailExists_NotExistingEmail_ReturnsFalse()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var result = profileService.EMailExists("invalid@local.domain");

            Assert.False(result);
        }

        /*[Theory]
        [InlineData(1, 3, 0.6f)]
        [InlineData(2, 2, 0.4f)]
        public void GetProfileByUserID_ExistingID_ReturnsValidPostsData(int userID, int expectedPostsCount, float expectedPercentageOfAllPosts)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var result = profileService.GetProfileByUserID(userID);
            
            Assert.Equal(expectedPostsCount, result.PostsCount);
            Assert.Equal(expectedPercentageOfAllPosts, result.PercentageOfAllPosts, 1);
        }*/

        [Theory]
        [InlineData(1, "Category 1", "cat-1")]
        [InlineData(2, "Category 1", "cat-1")]
        public void GetProfileByUserID_ExistingID_ReturnsValidMostActiveCategory(int userID, string expectedCategoryName, string expectedCategoryAlias)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var result = profileService.GetProfileByUserID(userID);

            Assert.Equal(expectedCategoryName, result.MostActiveCategory.CategoryName);
            Assert.Equal(expectedCategoryAlias, result.MostActiveCategory.CategoryAlias);
        }
        
        [Theory]
        [InlineData(1, "Topic 2", "top-2", "cat-1")]
        [InlineData(2, "Topic 4", "top-4", "cat-2")]
        public void GetProfileByUserID_ExistingID_ReturnsValidMostActiveTopic(int userID, string expectedTopicName, string expectedTopicAlias, string expectedTopicCategoryAlias)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var result = profileService.GetProfileByUserID(userID);

            Assert.Equal(expectedTopicName, result.MostActiveTopic.TopicName);
            Assert.Equal(expectedTopicAlias, result.MostActiveTopic.TopicAlias);
            Assert.Equal(expectedTopicCategoryAlias, result.MostActiveTopic.TopicCategoryAlias);
        }

        [Fact]
        public void GetProfileByUserID_NotExistingID_ThrowsUserProfileNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(p => p.Now()).Returns(new DateTime(2016, 1, 1));

            var profileService = new ProfileService(testDatabaseContext, timeProviderMock.Object);
            var exception = Record.Exception(() => profileService.GetProfileByUserID(1001));

            Assert.IsType<UserProfileNotFoundException>(exception);
        }
    }
}
