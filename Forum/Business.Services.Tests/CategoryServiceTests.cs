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
        IEnumerable<Category> GetCategoriesData()
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

            return data;
        }

        [Fact]
        public void GetCategoryWithPosts_ValidCategoryAlias_ValidReturnedCategory()
        {
            var data = GetCategoriesData();
            var fakeDbSet = FakeDbSetFactory.Create<Category>(data);

            var databaseContext = new Mock<IDatabaseContext>();
            databaseContext.Setup(p => p.Categories).Returns(fakeDbSet.Object);

            var service = new CategoryService(databaseContext.Object);
            var result = service.GetCategoryWithPosts("cat-1");

            Assert.Equal("Category 1", result.Name);
            Assert.Equal("cat-1", result.Alias);
        }

        [Fact]
        public void GetCategoryWithPosts_ValidCategoryAlias_ValidReturnedCategoryTopics()
        {
            var data = GetCategoriesData();
            var fakeDbSet = FakeDbSetFactory.Create<Category>(data);

            var databaseContext = new Mock<IDatabaseContext>();
            databaseContext.Setup(p => p.Categories).Returns(fakeDbSet.Object);

            var service = new CategoryService(databaseContext.Object);
            var result = service.GetCategoryWithPosts("cat-1");

            Assert.Equal(2, result.Topics.Count());

            Assert.Equal("Topic 1", result.Topics.ElementAt(0).Name);
            Assert.Equal("Topic 2", result.Topics.ElementAt(1).Name);

            Assert.Equal("top-1", result.Topics.ElementAt(0).Alias);
            Assert.Equal("top-2", result.Topics.ElementAt(1).Alias);
        }

        [Fact]
        public void GetCategoryWithPosts_BadAlias_CategoryNotFoundException()
        {
            var data = GetCategoriesData();
            var fakeDbSet = FakeDbSetFactory.Create<Category>(data);

            var databaseContext = new Mock<IDatabaseContext>();
            databaseContext.Setup(p => p.Categories).Returns(fakeDbSet.Object);

            var service = new CategoryService(databaseContext.Object);
            var result = Record.Exception(() => service.GetCategoryWithPosts("bad-category-alias"));

            Assert.Equal(typeof(CategoryNotFoundException), result.GetType());
            Assert.Equal("bad-category-alias", result.Message);
        }

        [Fact]
        public void Exists_ValidData_CategoryExists()
        {
            var data = GetCategoriesData();

            var fakeDbSet = FakeDbSetFactory.Create<Category>(data);

            var databaseContext = new Mock<IDatabaseContext>();
            databaseContext.Setup(p => p.Categories).Returns(fakeDbSet.Object);

            var service = new CategoryService(databaseContext.Object);
            var result = service.Exists("cat-3");

            Assert.True(result);
        }

        [Fact]
        public void Exists_NoCategory_CategoryNotExists()
        {
            var data = GetCategoriesData();

            var fakeDbSet = FakeDbSetFactory.Create<Category>(data);

            var databaseContext = new Mock<IDatabaseContext>();
            databaseContext.Setup(p => p.Categories).Returns(fakeDbSet.Object);

            var service = new CategoryService(databaseContext.Object);
            var result = service.Exists("bad-category-alias");

            Assert.False(result);
        }
    }
}
