using DataAccess.Database;

namespace Business.Services.PostServices
{
    /// <summary>
    /// Represents a set of methods to manage posts.
    /// </summary>
    public class PostService : ServiceBase, IPostService
    {
        private IDatabaseContext _databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostService"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public PostService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
