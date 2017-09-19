using Business.Services.ConfigServices;
using Business.Services.Tests.Helpers.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    public class ConfigServiceTests
    {
        [Fact]
        public void GetValue_ExistingKey_ReturnsValidStringValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var result = service.GetValue<string>("Key1");

            Assert.Equal("String value", result);
        }

        [Fact]
        public void GetValue_ExistingKey_ReturnsValidBoolTrueValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var result = service.GetValue<bool>("Key2");

            Assert.True(result);
        }

        [Fact]
        public void GetValue_ExistingKey_ReturnsValidBoolFalseValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var result = service.GetValue<bool>("Key3");

            Assert.False(result);
        }

        [Fact]
        public void GetValue_ExistingKey_ReturnsValidIntegerValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var result = service.GetValue<int>("Key4");

            Assert.Equal(123, result);
        }

        [Fact]
        public void GetValue_ExistingKey_ReturnsValidFloatValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var result = service.GetValue<float>("Key5");

            Assert.Equal(10.34f, result);
        }

        [Fact]
        public void GetValue_NotExistingKey_ThrowsKeyNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var exception = Record.Exception(() => service.GetValue<float>("Not existing key"));

            Assert.IsType<KeyNotFoundException>(exception);
        }
    }
}
