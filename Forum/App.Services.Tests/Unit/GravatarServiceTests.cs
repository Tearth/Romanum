﻿using App.Services.GravatarServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace App.Services.Tests.Unit
{
    public class GravatarServiceTests
    {
        [Theory]
        [InlineData("MyEmailAddress@example.com", "0bc83cb571cd1c50ba6f3e8a78ef1346")]
        [InlineData("strange_ADDRESS@local.dOmAiN", "4db77955e5ed36f6643ed160cef6c402")]
        [InlineData("  address_without_trim@local.domain      ", "79b58d4b15a35576c5ffdddf6992cc36")]
        public void GetGravatarHash_ValidEMail_ReturnsValidMD5Hash(string email, string expectedHash)
        {
            var gravatarService = new GravatarService();

            var hash = gravatarService.GetGravatarHash(email);

            Assert.Equal(expectedHash, hash);
        }
    }
}
