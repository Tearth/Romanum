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
        private Mock<IDatabaseContext> GetDatabaseContextMock()
        {
            var data = new List<Section>();

            var firstSection = new Section("Section 1", "sec-1");
            var secondSection = new Section("Section 2", "sec-2");
            var thirdSection = new Section("Section 3", "sec-3");

            data.Add(firstSection);
            data.Add(secondSection);
            data.Add(thirdSection);

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

            var fakeDbSet = FakeDbSetFactory.Create<Section>(data);
            var fakeDatabaseContext = new Mock<IDatabaseContext>();
            fakeDatabaseContext.Setup(p => p.Sections).Returns(fakeDbSet.Object);

            return fakeDatabaseContext;
        }

        [Fact]
        public void GetAllSetionsWithCategories_ValidData_ValidCategories()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new SectionService(databaseContextMock.Object);
            var result = service.GetAllSetionsWithCategories();

            Assert.Equal("Category 1", result.ElementAt(0).Categories.ElementAt(0).Name);
            Assert.Equal("Category 2", result.ElementAt(0).Categories.ElementAt(1).Name);
            Assert.Equal("Category 3", result.ElementAt(1).Categories.ElementAt(0).Name);
        }

        [Fact]
        public void GetAllSetionsWithCategories_ValidData_ValidLastPostTime()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new SectionService(databaseContextMock.Object);
            var result = service.GetAllSetionsWithCategories();
            
            Assert.Equal(new DateTime(2003, 3, 27).Date, result.ElementAt(0).Categories.ElementAt(0).LastPostTime.Date);
            Assert.Equal(new DateTime(2004, 2, 1).Date, result.ElementAt(0).Categories.ElementAt(1).LastPostTime.Date);
            Assert.Equal(default(DateTime), result.ElementAt(1).Categories.ElementAt(0).LastPostTime.Date);
        }

        [Fact]
        public void GetAllSetionsWithCategories_EmptySection_NoCategories()
        {
            var databaseContextMock = GetDatabaseContextMock();

            var service = new SectionService(databaseContextMock.Object);
            var result = service.GetAllSetionsWithCategories();

            Assert.Equal(0, result.ElementAt(2).Categories.Count());
        }
    }
}
