using App.Services.AuthServices;
using App.Services.AuthServices.Exceptions;
using App.Services.AuthServices.Security;
using App.Services.DTO.Auth;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace App.Services.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void CreateUser_NotExistingUserName_WrapperCreateUserCalled()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.UserExists("TestUserName")).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var userDTO = new NewUserDTO()
            {
                Name = "TestUserName",
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
            var userDTO = new NewUserDTO()
            {
                Name = "TestUserName",
                Password = "TestPassword",
                EMail = "user@local.domain"
            };

            var exception = Record.Exception(() => authService.CreateUser(userDTO));

            Assert.IsType<UserNameExistsException>(exception);
        }

        [Fact]
        public void UserExists_ExistingUserName_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.UserExists("TestUserName")).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.UserExists("TestUserName");

            Assert.True(result);
        }

        [Fact]
        public void UserExists_NotExistingUserName_ReturnsFalse()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            webSecurityWrapperMock.Setup(p => p.UserExists("TestUserName")).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.UserExists("TestUserName");

            Assert.False(result);
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
            var logInDataDTO = new LogInDTO()
            {
                Name = "TestUserName",
                Password = "TestUserPassword",
                RememberMe = true
            };

            webSecurityWrapperMock.Setup(p => p.LogIn(logInDataDTO)).Returns(true);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.LogIn(logInDataDTO);

            Assert.True(result);
        }

        [Fact]
        public void LogIn_InvalidUserNamePassword_ReturnsTrue()
        {
            var webSecurityWrapperMock = new Mock<IWebSecurityWrapper>();
            var logInDataDTO = new LogInDTO()
            {
                Name = "TestUserName",
                Password = "TestUserPassword",
                RememberMe = true
            };

            webSecurityWrapperMock.Setup(p => p.LogIn(logInDataDTO)).Returns(false);

            var authService = new AuthService(webSecurityWrapperMock.Object);
            var result = authService.LogIn(logInDataDTO);

            Assert.True(result);
        }
    }
}
