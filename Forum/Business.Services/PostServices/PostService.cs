using DataAccess.Database;

namespace Business.Services.PostServices
{
    public class PostService : ServiceBase, IPostService
    {
        private IDatabaseContext _databaseContext;

        public PostService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
