using System.Linq;
using Business.Services.Tests.Helpers.Database;
using Business.Services.TopicServices;
using Business.Services.TopicServices.Exceptions;
using Xunit;

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    public class TopicServiceTests
    {
        public TopicServiceTests()
        {
            DbContextFactory.Init();
        }

        [Theory]
        [InlineData("top-1", 1, "Topic 1")]
        [InlineData("top-2", 2, "Topic 2")]
        [InlineData("top-3", 3, "Topic 3")]
        [InlineData("top-4", 4, "Topic 4")]
        public void GetTopicWithPosts_ExistingTopicAlias_ReturnsValidTopicData(string topicAlias, int expectedTopicID, string expectedTopicName)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new TopicService(testDatabaseContext);
            var topic = service.GetTopicWithPosts(topicAlias);

            Assert.Equal(expectedTopicID, topic.ID);
            Assert.Equal(expectedTopicName, topic.Name);
        }

        [Theory]
        [InlineData("top-1", 1)]
        [InlineData("top-2", 3)]
        [InlineData("top-3", 2)]
        [InlineData("top-4", 2)]
        public void GetTopicWithPosts_ExistingTopicAlias_ReturnsValidPostsCount(string topicAlias, int expectedPostsCount)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new TopicService(testDatabaseContext);
            var topic = service.GetTopicWithPosts(topicAlias);

            Assert.Equal(expectedPostsCount, topic.Posts.Count());
        }

        [Fact]
        public void GetTopicWithPosts_NotExistingTopicAlias_ThrowsTopicNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new TopicService(testDatabaseContext);
            var exception = Record.Exception(() => service.GetTopicWithPosts("bad-topic-alias"));

            Assert.IsType<TopicNotFoundException>(exception);
        }

        [Theory]
        [InlineData("top-1")]
        [InlineData("top-2")]
        [InlineData("top-3")]
        [InlineData("top-4")]
        public void Exists_ExistingTopicAlias_ReturnsTrue(string topicAlias)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new TopicService(testDatabaseContext);
            var result = service.Exists(topicAlias);

            Assert.True(result);
        }

        [Fact]
        public void Exists_NotExistingTopicAlias_ReturnsFalse()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new TopicService(testDatabaseContext);
            var result = service.Exists("bad-topic-alias");

            Assert.False(result);
        }

        [Theory]
        [InlineData("top-1", "cat-1")]
        [InlineData("top-2", "cat-1")]
        [InlineData("top-3", "cat-1")]
        [InlineData("top-4", "cat-2")]
        public void ValidateTopicAndCategoryAlias_ExistingTopicAlias_ReturnsTrue(string topicAlias, string categoryAlias)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new TopicService(testDatabaseContext);
            var result = service.ValidateTopicAndCategoryAlias(topicAlias, categoryAlias);

            Assert.True(result);
        }

        [Theory]
        [InlineData("top-1", "bad-category-alias")]
        [InlineData("bad-topic-alias", "bad-category-alias")]
        [InlineData("bad-topic-alias", "cat-3")]
        public void ValidateTopicAndCategoryAlias_NotExistingCategoryAlias_ReturnsFalse(string topicAlias, string categoryAlias)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new TopicService(testDatabaseContext);
            var result = service.ValidateTopicAndCategoryAlias(topicAlias, categoryAlias);

            Assert.False(result);
        }
    }
}
