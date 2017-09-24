using Business.Services.CategoryServices;
using Business.Services.CategoryServices.Exceptions;
using Business.Services.Tests.Helpers;
using Business.Services.Tests.Helpers.Database;
using DataAccess.Database;
using DataAccess.Entities;
using Moq;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    public class CategoryServiceTests
    {
        public CategoryServiceTests()
        {
            DbContextFactory.Init();
        }

        [Theory]
        [InlineData("cat-1", "Category 1")]
        [InlineData("cat-2", "Category 2")]
        [InlineData("cat-3", "Category 3")]
        [InlineData("cat-4", "Category 4")]
        public void GetCategoryWithPosts_ExistingCategoryAlias_ReturnsValidCategoryName(string categoryAlias, string expectedCategoryName)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new CategoryService(testDatabaseContext);
            var category = service.GetCategoryWithPosts(categoryAlias);

            Assert.Equal(expectedCategoryName, category.Name);
        }

        [Theory]
        [InlineData("cat-1", 3)]
        [InlineData("cat-2", 1)]
        [InlineData("cat-3", 0)]
        [InlineData("cat-4", 0)]
        public void GetCategoryWithPosts_ExistingCategoryAlias_ReturnsValidCategoryTopicsCount(string categoryAlias, int expectedTopicsCount)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new CategoryService(testDatabaseContext);
            var category = service.GetCategoryWithPosts(categoryAlias);

            Assert.Equal(expectedTopicsCount, category.Topics.Count());
        }

        [Fact]
        public void GetCategoryWithPosts_NotExistingCategoryAlias_ThrowsCategoryNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new CategoryService(testDatabaseContext);
            var exception = Record.Exception(() => service.GetCategoryWithPosts("bad-category-alias"));

            Assert.IsType<CategoryNotFoundException>(exception);
        }

        [Theory]
        [InlineData("cat-1")]
        [InlineData("cat-2")]
        [InlineData("cat-3")]
        [InlineData("cat-4")]
        public void Exists_ExistingCategoryAlias_ReturnsTrue(string categoryAlias)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new CategoryService(testDatabaseContext);
            var result = service.Exists(categoryAlias);

            Assert.True(result);
        }

        [Fact]
        public void Exists_NotExistingCategoryAlias_ReturnsFalse()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new CategoryService(testDatabaseContext);
            var result = service.Exists("bad-category-alias");

            Assert.False(result);
        }
    }
}
