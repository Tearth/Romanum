using Business.Services.Tests.Helpers.Database;

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
