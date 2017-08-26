using Domain.Entities.Content;
using Domain.Services.Database;
using Domain.Services.SectionServices;
using Domain.Services.Tests.Helpers;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Services.Tests
{
    public class SectionServiceTests
    {
        List<Section> GetSectionsData()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture.CreateMany<Section>(3).ToList();
        }

        [Fact]
        public void GetAllSetionsWithCategories_ValidData_ValidResult()
        {
            var data = GetSectionsData();

            data[0].Categories.ElementAt(1)
                   .Topics.ElementAt(2)
                   .Posts.Add(new Post("Test content", new DateTime(3100, 1, 5)));

            var fakeDbSet = FakeDbSetFactory.Create<Section>(data);
    
            var databaseContext = new Mock<IDatabaseContext>();
            databaseContext.Setup(p => p.Sections).Returns(fakeDbSet.Object);

            var service = new SectionService(databaseContext.Object);
            var result = service.GetAllSetionsWithCategories();

            Assert.Equal(new DateTime(3100, 1, 5).Date, result.ElementAt(0).Categories.ElementAt(1).LastPostTime.Date);
        }
    }
}
