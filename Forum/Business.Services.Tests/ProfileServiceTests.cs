using Business.Services.ProfileServices;
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

            var firstUser = new User("Test user 1") { ID = 1, EMail = "user1@domain.local" };
            var secondUser = new User("Test user 2") { ID = 2, EMail = "user2@domain.local" };
            var thirdUser = new User("Test user 3") { ID = 3, EMail = "user3@domain.local" };

            users.AddMany(firstUser, secondUser, thirdUser);

            var firstPost = new Post("Content 1", new DateTime(2000, 5, 10)) { ID = 1, Author = firstUser };
            var secondPost = new Post("Content 2", new DateTime(2001, 1, 2)) { ID = 2, Author = firstUser };
            var thirdPost = new Post("Content 3", new DateTime(2002, 10, 12)) { ID = 3, Author = firstUser };
            var fourthPost = new Post("Content 4", new DateTime(2003, 3, 27)) { ID = 4, Author = secondUser };
            var fifthPost = new Post("Content 5", new DateTime(2004, 2, 1)) { ID = 5, Author = secondUser };

            firstUser.Posts.AddMany(firstPost, secondPost, thirdPost);
            secondUser.Posts.AddMany(fourthPost, fifthPost);

            var postsList = users.SelectMany(p => p.Posts);

            var usersFakeDbSet = FakeDbSetFactory.Creation<User>(users);
            var postsFakeDbSet = FakeDbSetFactory.Creation<Post>(postsList);

            var fakeDatabaseContext = new Mock<IDatabaseContext>();
            fakeDatabaseContext.Setup(p => p.Users).Returns(usersFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Posts).Returns(postsFakeDbSet.Object);

            return fakeDatabaseContext;
        }

        [Theory]
        [InlineData("Test user 1")]
        [InlineData("Test user 2")]
        [InlineData("Test user 3")]
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
        [InlineData("user1@domain.local")]
        [InlineData("user2@domain.local")]
        [InlineData("user3@domain.local")]
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
    }
}
