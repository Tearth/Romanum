using Business.Services.SectionServices;
using Business.Services.Tests.Helpers;
using Business.Services.Tests.Helpers.Database;
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

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    public class SectionServiceTests
    {
        [Fact]
        public void GetAllSetionsWithCategories_ReturnsValidCategoriesData()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new SectionService(testDatabaseContext);
            var sections = service.GetAllSetionsWithCategories();

            Assert.Equal("Category 1", sections.ElementAt(0).Categories.ElementAt(0).Name);
            Assert.Equal("Category 2", sections.ElementAt(0).Categories.ElementAt(1).Name);
            Assert.Equal("Category 3", sections.ElementAt(1).Categories.ElementAt(0).Name);
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsValidLastPostCreationTime()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new SectionService(testDatabaseContext);
            var sections = service.GetAllSetionsWithCategories();
            
            Assert.Equal(new DateTime(2003, 3, 27).Date, sections.ElementAt(0).Categories.ElementAt(0).LastPostCreationTime.Date);
            Assert.Equal(new DateTime(2004, 2, 1).Date, sections.ElementAt(0).Categories.ElementAt(1).LastPostCreationTime.Date);
            Assert.Equal(default(DateTime), sections.ElementAt(1).Categories.ElementAt(0).LastPostCreationTime.Date);
        }

        [Fact]
        public void GetAllSetionsWithCategories_ReturnsSectionWithoutCategories()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new SectionService(testDatabaseContext);
            var sections = service.GetAllSetionsWithCategories();

            Assert.Equal(0, sections.ElementAt(2).Categories.Count());
        }
    }
}
