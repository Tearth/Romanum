using Business.Services.SectionServices;
using Business.Services.Tests.Helpers;
using Business.Services.Tests.Helpers.Database;
using DataAccess.Database;
using DataAccess.Entities;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    public class SectionServiceTests
    {
        public SectionServiceTests()
        {
            DbContextFactory.Init();
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsValidCategoriesData()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new SectionService(testDatabaseContext);
            var sections = service.GetAllSetionsWithCategories();

            Assert.Equal("Category 1", sections.ElementAt(0).Categories.ElementAt(0).Name);
            Assert.Equal("Category 2", sections.ElementAt(0).Categories.ElementAt(1).Name);
            Assert.Equal("Category 3", sections.ElementAt(1).Categories.ElementAt(0).Name);
            Assert.Equal("Category 4", sections.ElementAt(1).Categories.ElementAt(1).Name);
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsValidCategoriesCount()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new SectionService(testDatabaseContext);
            var sections = service.GetAllSetionsWithCategories();

            Assert.Equal(2, sections.ElementAt(0).Categories.Count());
            Assert.Equal(2, sections.ElementAt(1).Categories.Count());
            Assert.Equal(0, sections.ElementAt(2).Categories.Count());
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsValidLastPostCreationTime()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new SectionService(testDatabaseContext);
            var sections = service.GetAllSetionsWithCategories();
            
            Assert.Equal(new DateTime(2015, 6, 6).Date, sections.ElementAt(0).Categories.ElementAt(0).LastPostCreationTime.Date);
            Assert.Equal(new DateTime(2015, 8, 8).Date, sections.ElementAt(0).Categories.ElementAt(1).LastPostCreationTime.Date);
            Assert.Equal(default(DateTime).Date, sections.ElementAt(1).Categories.ElementAt(0).LastPostCreationTime.Date);
            Assert.Equal(default(DateTime).Date, sections.ElementAt(1).Categories.ElementAt(1).LastPostCreationTime.Date);
        }
    }
}
