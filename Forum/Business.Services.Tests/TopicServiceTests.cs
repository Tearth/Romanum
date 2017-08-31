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
        private Mock<IDatabaseContext> GetDatabaseContextMock()
        {
            var data = new List<Category>();

            var firstCategory = new Category("Category 1", "cat-1") { ID = 1 };
            var secondCategory = new Category("Category 2", "cat-2") { ID = 2 };
            var thirdCategory = new Category("Category 3", "cat-3") { ID = 3 };

            data.Add(firstCategory);
            data.Add(secondCategory);
            data.Add(thirdCategory);

            var firstTopic = new Topic("Topic 1", "top-1") { ID = 1, Category = firstCategory };
            var secondTopic = new Topic("Topic 2", "top-2") { ID = 2, Category = firstCategory };
            var thirdTopic = new Topic("Topic 3", "top-3") { ID = 3, Category = secondCategory };

            firstCategory.Topics.Add(firstTopic);
            firstCategory.Topics.Add(secondTopic);
            secondCategory.Topics.Add(thirdTopic);

            var firstPost = new Post("Content 1", new DateTime(2000, 5, 10)) { ID = 1, Topic = firstTopic };
            var secondPost = new Post("Content 2", new DateTime(2001, 1, 2)) { ID = 2, Topic = firstTopic };
            var thirdPost = new Post("Content 3", new DateTime(2002, 10, 12)) { ID = 3, Topic = firstTopic };
            var fourthPost = new Post("Content 4", new DateTime(2003, 3, 27)) { ID = 4, Topic = secondTopic };
            var fifthPost = new Post("Content 5", new DateTime(2004, 2, 1)) { ID = 5, Topic = thirdTopic };

            firstTopic.Posts.Add(firstPost);
            firstTopic.Posts.Add(secondPost);
            firstTopic.Posts.Add(thirdPost);
            secondTopic.Posts.Add(fourthPost);
            thirdTopic.Posts.Add(fifthPost);

            var topicsList = data.SelectMany(p => p.Topics);
            var postsList = topicsList.SelectMany(p => p.Posts);

            var categoriesFakeDbSet = FakeDbSetFactory.Creation<Category>(data);
            var topicsFakeDbSet = FakeDbSetFactory.Creation<Topic>(topicsList);
            var postsFakeDbSet = FakeDbSetFactory.Creation<Post>(postsList);

            var fakeDatabaseContext = new Mock<IDatabaseContext>();
            fakeDatabaseContext.Setup(p => p.Categories).Returns(categoriesFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Topics).Returns(topicsFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Posts).Returns(postsFakeDbSet.Object);

            return fakeDatabaseContext;
        }

        [Fact]
        public void GetTopicWithPosts_ExistingTopicAlias_ReturnsValidTopicData()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.GetTopicWithPosts("top-1");

            Assert.Equal("Topic 1", result.Name);
            Assert.Equal("top-1", result.Alias);
        }

        [Fact]
        public void GetTopicWithPosts_ExistingTopicAlias_ReturnsValidPosts()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.GetTopicWithPosts("top-1");

            Assert.Equal(3, result.Posts.Count());
            Assert.Equal("Content 1", result.Posts.ElementAt(0).Content);
            Assert.Equal("Content 2", result.Posts.ElementAt(1).Content);
            Assert.Equal("Content 3", result.Posts.ElementAt(2).Content);
            Assert.Equal(new DateTime(2000, 5, 10).Date, result.Posts.ElementAt(0).CreationTime.Date);
            Assert.Equal(new DateTime(2001, 1, 2).Date, result.Posts.ElementAt(1).CreationTime.Date);
            Assert.Equal(new DateTime(2002, 10, 12).Date, result.Posts.ElementAt(2).CreationTime.Date);
        }

        [Fact]
        public void GetTopicWithPosts_InvalidTopicAlias_ThrowsTopicNotFoundException()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = Record.Exception(() => service.GetTopicWithPosts("bad-topic-alias"));

            Assert.Equal(typeof(TopicNotFoundException), result.GetType());
            Assert.Equal("bad-topic-alias", result.Message);
        }

        [Fact]
        public void Exists_ExistingAlias_ReturnsTrue()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.Exists("top-1");

            Assert.True(result);
        }

        [Fact]
        public void Exists_InvalidAlias_ReturnsFalse()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.Exists("bad-topic-alias");

            Assert.False(result);
        }

        [Fact]
        public void ValidateTopicAndCategoryAlias_ExistingAlias_ReturnsTrue()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.ValidateTopicAndCategoryAlias("top-1", "cat-1");

            Assert.True(result);
        }

        [Fact]
        public void ValidateTopicAndCategoryAlias_InvalidCategoryAlias_ReturnsFalse()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new TopicService(databaseContextMock.Object);
            var result = service.ValidateTopicAndCategoryAlias("top-1", "bad-category-alias");

            Assert.False(result);
        }
    }
}
