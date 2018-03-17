using Business.Services.AvatarServices;
using Business.Services.ProfileServices.Exceptions;
using Business.Services.Tests.Helpers.Database;
using DataAccess.Entities.Enums;
using Xunit;

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    [UseMapper]
    public class AvatarServiceTests
    {
        public AvatarServiceTests()
        {
            DbContextFactory.Init();
        }

        [Theory]
        [InlineData(1, "/Content/Avatars/internal_1.png")]
        [InlineData(2, "gravatar.com/HASH")]
        public void GetUserAvatar_ExistingUserID_ReturnsValidUserAvatar(int userID, string expectedAvatarSource)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var userAvatar = service.GetUserAvatar(userID);

            Assert.Equal(expectedAvatarSource, userAvatar.Source);
        }

        [Fact]
        public void GetUserAvatar_NotExistingUserID_ThrowsUserProfileNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var exception = Record.Exception(() => service.GetUserAvatar(1001));

            Assert.IsType<UserProfileNotFoundException>(exception);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void SetUserAvatarToDefault_ExistingUserID_SetsUserAvatarToDefault(int userID)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            service.SetUserAvatarToDefault(userID);

            var userAvatar = service.GetUserAvatar(userID);
            Assert.Null(userAvatar);
        }

        [Fact]
        public void SetUserAvatarToDefault_NotExistingUserID_ThrowsUserProfileNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var exception = Record.Exception(() => service.SetUserAvatarToDefault(1001));

            Assert.IsType<UserProfileNotFoundException>(exception);
        }
    }
}
