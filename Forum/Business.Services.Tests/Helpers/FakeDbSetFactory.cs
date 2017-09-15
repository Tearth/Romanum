using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Tests.Helpers
{
    static class FakeDbSetFactory
    {
        public static Mock<DbSet<T>> Creation<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();
            
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            //Because DbSet mock throws ArgumentNullException when Include method is called
            //somewhere in LINQ query, for this reason we replace this method with own (which
            //only returns mock object).
            dbSetMock.Setup(p => p.Include(It.IsAny<string>())).Returns(dbSetMock.Object);

            return dbSetMock;
        }
    }
}
