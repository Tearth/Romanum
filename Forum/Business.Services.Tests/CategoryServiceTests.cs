using Business.Services.CategoryServices;
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
        List<Category> GetCategoriesData()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture.CreateMany<Category>(3).ToList();
        }

        [Fact]
        public void GetCategoryWithPosts_ValidData_CategoryHasValidData()
        {
            var data = GetCategoriesData();
            data[0].Name = "Test name";
            data[0].Alias = "test-alias";

            var topic = data[0].Topics.ElementAt(2);
            topic.Posts.Clear();

            topic.Posts.Add(new Post("Test content 1", new DateTime(2100, 1, 12)));
            topic.Posts.Add(new Post("Test content 1", new DateTime(2100, 1, 12)));
            topic.Posts.Add(new Post("Test content 1", new DateTime(2100, 1, 12)));
            
            var fakeDbSet = FakeDbSetFactory.Create<Category>(data);

            var databaseContext = new Mock<IDatabaseContext>();
            databaseContext.Setup(p => p.Categories).Returns(fakeDbSet.Object);

            var service = new CategoryService(databaseContext.Object);
            var result = service.GetCategoryWithPosts("test-alias");

            Assert.Equal("Test name", result.Name);
            Assert.Equal("test-alias", result.Alias);
            Assert.Equal(3, result.Topics.Count());
        }
    }
}
