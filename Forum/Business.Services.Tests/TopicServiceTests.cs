using Business.Services.Tests.Helpers;
using Business.Services.TopicServices;
using Business.Services.TopicServices.Exceptions;
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
    public class TopicServiceTests
    {
        Mock<IDatabaseContext> GetDatabaseContextMock()
        {
            var users = new List<User>();
            var categories = new List<Category>();

            var firstUser = new User("User 1") { ID = 1 };
            var secondUser = new User("User 2") { ID = 2 };

            users.AddMany(firstUser, secondUser);

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
        [InlineData("top-1", 1, "Topic 1")]
        [InlineData("top-2", 2, "Topic 2")]
        [InlineData("top-3", 3, "Topic 3")]
        public void GetTopicWithPosts_ExistingTopicAlias_ReturnsValidTopicData(string topicAlias, int expectedTopicID, string expectedTopicName)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var topic = service.GetTopicWithPosts(topicAlias);

            Assert.Equal(expectedTopicID, topic.ID);
            Assert.Equal(expectedTopicName, topic.Name);
        }

        [Theory]
        [InlineData("top-1", 3)]
        [InlineData("top-2", 1)]
        [InlineData("top-3", 1)]
        public void GetTopicWithPosts_ExistingTopicAlias_ReturnsValidPosts(string topicAlias, int expectedPostsCount)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var topic = service.GetTopicWithPosts(topicAlias);

            Assert.Equal(expectedPostsCount, topic.Posts.Count());
        }

        [Fact]
        public void GetTopicWithPosts_NotExistingTopicAlias_ThrowsTopicNotFoundException()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var exception = Record.Exception(() => service.GetTopicWithPosts("bad-topic-alias"));

            Assert.IsType<TopicNotFoundException>(exception);
        }

        [Theory]
        [InlineData("top-1")]
        [InlineData("top-2")]
        [InlineData("top-3")]
        public void Exists_ExistingTopicAlias_ReturnsTrue(string topicAlias)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.Exists(topicAlias);

            Assert.True(result);
        }

        [Fact]
        public void Exists_NotExistingTopicAlias_ReturnsFalse()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.Exists("bad-topic-alias");

            Assert.False(result);
        }

        [Theory]
        [InlineData("top-1", "cat-1")]
        [InlineData("top-2", "cat-1")]
        [InlineData("top-3", "cat-2")]
        public void ValidateTopicAndCategoryAlias_ExistingTopicAlias_ReturnsTrue(string topicAlias, string categoryAlias)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.ValidateTopicAndCategoryAlias(topicAlias, categoryAlias);

            Assert.True(result);
        }

        [Theory]
        [InlineData("top-1", "bad-category-alias")]
        [InlineData("bad-topic-alias", "bad-category-alias")]
        [InlineData("bad-topic-alias", "cat-3")]
        public void ValidateTopicAndCategoryAlias_NotExistingCategoryAlias_ReturnsFalse(string topicAlias, string categoryAlias)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.ValidateTopicAndCategoryAlias(topicAlias, categoryAlias);

            Assert.False(result);
        }
    }
}
