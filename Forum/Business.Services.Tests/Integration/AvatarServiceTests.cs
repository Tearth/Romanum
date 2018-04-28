using Business.Services.AvatarServices;
using Business.Services.DTO.Avatar;
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
            Assert.Equal((int)AvatarType.Default, (int)userAvatar.Type);
        }

        [Fact]
        public void SetUserAvatarToDefault_NotExistingUserID_ThrowsUserProfileNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var exception = Record.Exception(() => service.SetUserAvatarToDefault(1001));

            Assert.IsType<UserProfileNotFoundException>(exception);
        }

        [Theory]
        [InlineData(1, AvatarTypeDTO.Gravatar, "gravatarSource")]
        [InlineData(2, AvatarTypeDTO.InternalImage, "internalSource")]
        public void SetUserAvatar_ExistingUserID_AvatarSuccessfullyChanged(int userID, AvatarTypeDTO avatarType, string avatarSource)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var userAvatar = new ChangedAvatarDTO
            {
                Type = avatarType,
                Source = avatarSource
            };

            service.SetUserAvatar(userID, userAvatar);

            var updatedUserAvatar = service.GetUserAvatar(userID);

            Assert.Equal(avatarType, updatedUserAvatar.Type);
            Assert.Equal(avatarSource, updatedUserAvatar.Source);
        }

        [Fact]
        public void SetUserAvatar_NotExistingUserID_ThrowsUserProfileNotFoundException()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var userAvatar = new ChangedAvatarDTO
            {
                Type = AvatarTypeDTO.Gravatar,
                Source = "gravatarSource"
            };

            var exception = Record.Exception(() => service.SetUserAvatar(1001, userAvatar));

            Assert.IsType<UserProfileNotFoundException>(exception);
        }

        [Theory]
        [InlineData("image/png")]
        [InlineData("image/jpeg")]
        [InlineData("image/bmp")]
        public void CheckIfMimeTypeIsValid_ValidMimeType_ReturnsTrue(string mimeType)
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var validationResult = service.CheckIfMimeTypeIsValid(mimeType);

            Assert.True(validationResult);
        }

        [Fact]
        public void CheckIfMimeTypeIsValid_InvalidMimeType_ReturnsFalse()
        {
            var testDatabaseContext = DbContextFactory.Create();

            var service = new AvatarService(testDatabaseContext);
            var validationResult = service.CheckIfMimeTypeIsValid("text/someweirdtype");

            Assert.False(validationResult);
        }
    }
}
