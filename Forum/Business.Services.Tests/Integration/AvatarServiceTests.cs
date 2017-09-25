using Business.Services.AvatarServices;
using Business.Services.CategoryServices;
using Business.Services.CategoryServices.Exceptions;
using Business.Services.Tests.Helpers;
using Business.Services.Tests.Helpers.Database;
using DataAccess.Database;
using DataAccess.Entities;
using Moq;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Business.Services.Tests.Integration
{
    [AutoRollback]
    public class AvatarServiceTests
    {
        public AvatarServiceTests()
        {
            DbContextFactory.Init();
        }
    }
}
