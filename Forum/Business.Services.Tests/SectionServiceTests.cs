using Business.Services.SectionServices;
using Business.Services.Tests.Helpers;
using DataAccess.Database;
using DataAccess.Entities.Content;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Services.Tests
{
    public class SectionServiceTests
    {
        Mock<IDatabaseContext> GetDatabaseContextMock()
        {
            var sections = new List<Section>();
            var users = new List<User>();

            var firstUser = new User("User 1") { ID = 1 };
            var secondUser = new User("User 2") { ID = 2 };

            users.Add(firstUser);
            users.Add(secondUser);

            var firstSection = new Section("Section 1", "sec-1");
            var secondSection = new Section("Section 2", "sec-2");
            var thirdSection = new Section("Section 3", "sec-3");

            sections.Add(firstSection);
            sections.Add(secondSection);
            sections.Add(thirdSection);

            var firstCategory = new Category("Category 1", "cat-1") { ID = 1, Section = firstSection };
            var secondCategory = new Category("Category 2", "cat-2") { ID = 2, Section = firstSection };
            var thirdCategory = new Category("Category 3", "cat-3") { ID = 3, Section = secondSection };

            firstSection.Categories.Add(firstCategory);
            firstSection.Categories.Add(secondCategory);
            secondSection.Categories.Add(thirdCategory);

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

            var categoriesList = sections.SelectMany(p => p.Categories);
            var topicsList = categoriesList.SelectMany(p => p.Topics);
            var postsList = topicsList.SelectMany(p => p.Posts);

            var usersFakeDbSet = FakeDbSetFactory.Creation<User>(users);
            var sectionsFakeDbSet = FakeDbSetFactory.Creation<Section>(sections);
            var categoriesFakeDbSet = FakeDbSetFactory.Creation<Category>(categoriesList);
            var topicsFakeDbSet = FakeDbSetFactory.Creation<Topic>(topicsList);
            var postsFakeDbSet = FakeDbSetFactory.Creation<Post>(postsList);

            var fakeDatabaseContext = new Mock<IDatabaseContext>();
            fakeDatabaseContext.Setup(p => p.Users).Returns(usersFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Sections).Returns(sectionsFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Categories).Returns(categoriesFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Topics).Returns(topicsFakeDbSet.Object);
            fakeDatabaseContext.Setup(p => p.Posts).Returns(postsFakeDbSet.Object);

            return fakeDatabaseContext;
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsValidCategoriesData()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new SectionService(databaseContextMock.Object);
            var result = service.GetAllSetionsWithCategories();

            Assert.Equal("Category 1", result.ElementAt(0).Categories.ElementAt(0).Name);
            Assert.Equal("Category 2", result.ElementAt(0).Categories.ElementAt(1).Name);
            Assert.Equal("Category 3", result.ElementAt(1).Categories.ElementAt(0).Name);
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsValidLastPostCreationTime()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new SectionService(databaseContextMock.Object);
            var result = service.GetAllSetionsWithCategories();
            
            Assert.Equal(new DateTime(2003, 3, 27).Date, result.ElementAt(0).Categories.ElementAt(0).LastPostCreationTime.Date);
            Assert.Equal(new DateTime(2004, 2, 1).Date, result.ElementAt(0).Categories.ElementAt(1).LastPostCreationTime.Date);
            Assert.Equal(default(DateTime), result.ElementAt(1).Categories.ElementAt(0).LastPostCreationTime.Date);
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsSectionWithoutCategories()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new SectionService(databaseContextMock.Object);
            var result = service.GetAllSetionsWithCategories();

            Assert.Equal(0, result.ElementAt(2).Categories.Count());
        }
    }
}
