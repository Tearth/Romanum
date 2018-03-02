using App.Services.AuthServices;
using App.Services.AuthServices.Exceptions;
using App.Services.AuthServices.Security;
using App.Services.DTO.Auth;
using Moq;
using Xunit;

namespace App.Services.Tests.Unit
{
    public class AuthServiceTests
    {
        [Fact]
        public void CreateUser_NotExistingUserName_WrapperCreateUserCalled()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.UserExists("TestUserName")).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var userDTO = new RegistrationDTO
            {
                UserName = "TestUserName",
                Password = "TestPassword",
                EMail = "user@local.domain"
            };

            authService.CreateUser(userDTO);

            webSecurityWrapperMock.Verify(p => p.CreateUser(userDTO));
        }

        [Fact]
        public void CreateUser_ExistingUserName_WrapperCreateUserCalled()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.UserExists("TestUserName")).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var userDTO = new RegistrationDTO
            {
                UserName = "TestUserName",
                Password = "TestPassword",
                EMail = "user@local.domain"
            };

            var exception = Record.Exception(() => authService.CreateUser(userDTO));

            Assert.IsType<UserNameAlreadyExistsException>(exception);
        }

        [Fact]
        public void IsUserLoggedIn_UserIsLoggedIn_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.IsUserLoggedIn()).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.IsUserLoggedIn();

            Assert.True(result);
        }

        [Fact]
        public void IsUserLoggedIn_UserIsNotLoggedIn_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.IsUserLoggedIn()).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.IsUserLoggedIn();

            Assert.False(result);
        }

        [Fact]
        public void LogIn_ValidUserNamePassword_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            var logInDataDTO = new LogInDTO
            {
                UserName = "TestUserName",
                Password = "TestUserPassword",
                RememberMe = true
            };

            webSecurityWrapperMock.Setup(p => p.LogIn(logInDataDTO)).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.LogIn(logInDataDTO);

            Assert.True(result);
        }

        [Fact]
        public void LogIn_InvalidUserNamePassword_ReturnsFalse()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            var logInDataDTO = new LogInDTO
            {
                UserName = "TestUserName",
                Password = "TestUserPassword",
                RememberMe = true
            };

            webSecurityWrapperMock.Setup(p => p.LogIn(logInDataDTO)).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.LogIn(logInDataDTO);

            Assert.False(result);
        }

        [Fact]
        public void LogOut_UserLoggedIn_WrapperLogOutCalled()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.IsUserLoggedIn()).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);

            authService.LogOut();

            webSecurityWrapperMock.Verify(p => p.LogOut());
        }

        [Fact]
        public void LogOut_UserNotLoggedIn_WrapperLogOutCalled()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.IsUserLoggedIn()).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var exception = Record.Exception(() => authService.LogOut());

            Assert.IsType<UserNotLoggedInException>(exception);
        }

        [Fact]
        public void ChangePassword_ValidOldNewPasswords_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            var changePasswordDTO = new ChangePasswordDTO
            {
                Name = "UserNameTest",
                OldPassword = "OldPassword",
                NewPassword = "NewPassword"
            };

            webSecurityWrapperMock.Setup(p => p.UserExists("UserNameTest")).Returns(true);
            webSecurityWrapperMock.Setup(p => p.ChangePassword(changePasswordDTO)).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.ChangePassword(changePasswordDTO);

            Assert.True(result);
        }

        [Fact]
        public void ChangePassword_InvalidOldOrNewPassword_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            var changePasswordDTO = new ChangePasswordDTO
            {
                Name = "UserNameTest",
                OldPassword = "OldPassword",
                NewPassword = "NewPassword"
            };

            webSecurityWrapperMock.Setup(p => p.UserExists("UserNameTest")).Returns(true);
            webSecurityWrapperMock.Setup(p => p.ChangePassword(changePasswordDTO)).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.ChangePassword(changePasswordDTO);

            Assert.False(result);
        }

        [Fact]
        public void ChangePassword_NotExistingUserName_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            var changePasswordDTO = new ChangePasswordDTO
            {
                Name = "UserNameTest",
                OldPassword = "OldPassword",
                NewPassword = "NewPassword"
            };

            webSecurityWrapperMock.Setup(p => p.UserExists("UserNameTest")).Returns(false);
            webSecurityWrapperMock.Setup(p => p.ChangePassword(changePasswordDTO)).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var exception = Record.Exception(() => authService.ChangePassword(changePasswordDTO));

            Assert.IsType<UserNameNotExistsException>(exception);
        }

        [Fact]
        public void GetCurrentUser_UserLoggedIn_ReturnsValidCurrentUserData()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            var currentUserDTO = new CurrentUserDTO
            {
                ID = 445,
                Name = "TestUserName"
            };

            webSecurityWrapperMock.Setup(p => p.IsUserLoggedIn()).Returns(true);
            webSecurityWrapperMock.Setup(p => p.GetCurrentUser()).Returns(currentUserDTO);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.GetCurrentUser();

            Assert.Equal(currentUserDTO.ID, result.ID);
            Assert.Equal(currentUserDTO.Name, result.Name);
        }

        [Fact]
        public void GetCurrentUser_UserNotLoggedIn_ReturnsValidCurrentUserData()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.IsUserLoggedIn()).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var exception = Record.Exception(() => authService.LogOut());

            Assert.IsType<UserNotLoggedInException>(exception);
        }
    }
}
