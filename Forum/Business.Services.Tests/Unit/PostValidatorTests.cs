using System;
using Business.Services.PostServices;
using Xunit;

namespace Business.Services.Tests.Unit
{
    public class PostValidatorTests
    {
        [Theory]
        [InlineData("valid content without any tag")]
        [InlineData("valid <b>content</b> with <h1>some</h1> <sTrOnG>tags</strong>")]
        public void IsValid_ValidContent_ReturnsTrue(string content)
        {
            var validator = new PostValidator();
            var result = validator.IsValid(content);

            Assert.True(result);
        }

        [Theory]
        [InlineData("invalid <applet>lorem ipsum</script> tags")]
        [InlineData("invalid <script>lorem ipsum</script> tags")]
        [InlineData("invalid <style>lorem ipsum</style> tags")]
        [InlineData("invalid <link>lorem ipsum</link> tags")]
        [InlineData("invalid <iframe>lorem ipsum</iframe> tags")]
        public void IsValid_InvalidContent_ReturnsFalse(string content)
        {
            var validator = new PostValidator();
            var result = validator.IsValid(content);

            Assert.False(result);
        }
    }
}
