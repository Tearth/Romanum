using System;
using Business.Services.PostServices;
using Xunit;

namespace Business.Services.Tests.Unit
{
    public class PostValidatorTests
    {
        [Theory]
        [InlineData("valid content without any tag", true)]
        [InlineData("valid <b>content</b> with <h1>some</h1> <sTrOnG>tags</strong>", true)]
        [InlineData("invalid <applet>lorem ipsum</script> tags", false)]
        [InlineData("invalid <script>lorem ipsum</script> tags", false)]
        [InlineData("invalid <style>lorem ipsum</style> tags", false)]
        [InlineData("invalid <link>lorem ipsum</link> tags", false)]
        [InlineData("invalid <iframe>lorem ipsum</iframe> tags", false)]
        [InlineData("shrt", false)]
        public void GetTopicWithPosts_ExistingTopicAlias_ReturnsValidTopicData(string content, bool expectedResult)
        {
            var validator = new PostValidator();
            var result = validator.IsValid(content);

            Assert.Equal(expectedResult, result);
        }
    }
}
