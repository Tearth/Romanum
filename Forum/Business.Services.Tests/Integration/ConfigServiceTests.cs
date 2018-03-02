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
        public ConfigServiceTests()
        {
            DbContextFactory.Init();
        }

        [Fact]
        public void GetValue_ExistingKey_ReturnsValidStringValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var result = service.GetValue<string>("Key1");

            Assert.Equal("String value", result);
        }

        [Fact]
        public void GetValue_ExistingKey_ReturnsValidBooleanTrueValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var result = service.GetValue<bool>("Key2");

            Assert.True(result);
        }

        [Fact]
        public void GetValue_ExistingKey_ReturnsValidBooleanFalseValue()
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

        [Fact]
        public void CreateOrUpdateKey_NotExistingKey_CreatesNewKey()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            service.CreateOrUpdateKey("NewKey", "Super long string value");

            var value = service.GetValue<string>("NewKey");
            Assert.Equal("Super long string value", value);
        }

        [Fact]
        public void CreateOrUpdateKey_ExistingKeyStringValue_UpdatedRecordHasValidValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            service.CreateOrUpdateKey("Key1", "Super long string value");

            var value = service.GetValue<string>("Key1");
            Assert.Equal("Super long string value", value);
        }

        [Fact]
        public void CreateOrUpdateKey_ExistingKeyTrueBooleanValue_UpdatedRecordHasValidValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            service.CreateOrUpdateKey("Key1", true);

            var value = service.GetValue<bool>("Key1");
            Assert.True(value);
        }

        [Fact]
        public void CreateOrUpdateKey_ExistingKeyFalseBooleanValue_UpdatedRecordHasValidValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            service.CreateOrUpdateKey("Key1", false);

            var value = service.GetValue<bool>("Key1");
            Assert.False(value);
        }

        [Fact]
        public void CreateOrUpdateKey_ExistingKeyIntegerValue_UpdatedRecordHasValidValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            service.CreateOrUpdateKey("Key1", 1001);

            var value = service.GetValue<int>("Key1");
            Assert.Equal(1001, value);
        }

        [Fact]
        public void CreateOrUpdateKey_ExistingKeyFloatValue_UpdatedRecordHasValidValue()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            service.CreateOrUpdateKey("Key1", 100.1234f);

            var value = service.GetValue<float>("Key1");
            Assert.Equal(100.1234f, value);
        }

        [Fact]
        public void RemoveKey_NotExistingKey_ThrowsKeyNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            var exception = Record.Exception(() => service.RemoveKey("Not existing key"));

            Assert.IsType<KeyNotFoundException>(exception);
        }

        [Theory]
        [InlineData("Key1")]
        [InlineData("Key2")]
        [InlineData("Key3")]
        [InlineData("Key4")]
        [InlineData("Key5")]
        public void RemoveKey_ExistingKey_GetValueThrowsKeyNotFoundException(string keyToRemove)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new ConfigService(testDatabaseContext);
            service.RemoveKey(keyToRemove);

            var exception = Record.Exception(() => service.RemoveKey(keyToRemove));

            Assert.IsType<KeyNotFoundException>(exception);
        }
    }
}
