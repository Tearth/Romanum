using Business.Services.CategoryServices;
using Business.Services.CategoryServices.Exceptions;
using Business.Services.Tests.Helpers;
using DataAccess.Database;
using DataAccess.Entities.Content;
using Moq;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Services.Tests
{
    public class CategoryServiceTests
    {
        Mock<IDatabaseContext> GetDatabaseContextMock()
        {
            var categories = new List<Category>();
            var users = new List<User>();

            var firstUser = new User("User 1") { ID = 1 };
            var secondUser = new User("User 2") { ID = 2 };

            users.Add(firstUser);
            users.Add(secondUser);

            var firstCategory = new Category("Category 1", "cat-1") { ID = 1 };
            var secondCategory = new Category("Category 2", "cat-2") { ID = 2 };
            var thirdCategory = new Category("Category 3", "cat-3") { ID = 3 };

            categories.Add(firstCategory);
            categories.Add(secondCategory);
            categories.Add(thirdCategory);

            var firstTopic = new Topic("Topic 1", "top-1") { ID = 1, Category = firstCategory };
            var secondTopic = new Topic("Topic 2", "top-2") { ID = 2, Category = firstCategory };
            var thirdTopic = new Topic("Topic 3", "top-3") { ID = 3, Category = secondCategory };

            firstCategory.Topics.Add(firstTopic);
            firstCategory.Topics.Add(secondTopic);
            secondCategory.Topics.Add(thirdTopic);

            var firstPost = new Post("Content 1", new DateTime(2000, 5, 10)) { ID = 1, Topic = firstTopic, Author = firstUser };
            var secondPost = new Post("Content 2", new DateTime(2001, 1, 2)) { ID = 2, Topic = firstTopic, Author = firstUser };
            var thirdPost = new Post("Content 3", new DateTime(2002, 10, 12)) { ID = 3, Topic = firstTopic, Author = secondUser };
            var fourthPost = new Post("Content 4", new DateTime(2003, 3, 27)) { ID = 4, Topic = secondTopic, Author = secondUser };
            var fifthPost = new Post("Content 5", new DateTime(2004, 2, 1)) { ID = 5, Topic = thirdTopic, Author = firstUser };

            firstTopic.Posts.Add(firstPost);
            firstTopic.Posts.Add(secondPost);
            firstTopic.Posts.Add(thirdPost);
            secondTopic.Posts.Add(fourthPost);
            thirdTopic.Posts.Add(fifthPost);

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
        [InlineData("cat-1", "Category 1")]
        [InlineData("cat-2", "Category 2")]
        [InlineData("cat-3", "Category 3")]
        public void GetCategoryWithPosts_ExistingCategoryAlias_ReturnsValidCategoryName(string categoryAlias, string expectedCategoryName)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new CategoryService(databaseContextMock.Object);
            var category = service.GetCategoryWithPosts(categoryAlias);

            Assert.Equal(expectedCategoryName, category.Name);
        }

        [Theory]
        [InlineData("cat-1", 2)]
        [InlineData("cat-2", 1)]
        [InlineData("cat-3", 0)]
        public void GetCategoryWithPosts_ExistingCategoryAlias_ReturnsValidCategoryTopicsCount(string categoryAlias, int expectedTopicsCount)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new CategoryService(databaseContextMock.Object);
            var category = service.GetCategoryWithPosts(categoryAlias);

            Assert.Equal(expectedTopicsCount, category.Topics.Count());
        }

        [Fact]
        public void GetCategoryWithPosts_NotExistingCategoryAlias_ThrowsCategoryNotFoundException()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new CategoryService(databaseContextMock.Object);
            var exception = Record.Exception(() => service.GetCategoryWithPosts("bad-category-alias"));

            Assert.Equal(typeof(CategoryNotFoundException), exception.GetType());
            Assert.Equal("bad-category-alias", exception.Message);
        }

        [Theory]
        [InlineData("cat-1")]
        [InlineData("cat-2")]
        [InlineData("cat-3")]
        public void Exists_ExistingCategoryAlias_ReturnsTrue(string categoryAlias)
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new CategoryService(databaseContextMock.Object);
            var result = service.Exists(categoryAlias);

            Assert.True(result);
        }

        [Fact]
        public void Exists_NotExistingCategoryAlias_ReturnsFalse()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new CategoryService(databaseContextMock.Object);
            var result = service.Exists("bad-category-alias");

            Assert.False(result);
        }
    }
}
