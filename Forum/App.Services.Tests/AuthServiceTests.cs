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
    }
}
