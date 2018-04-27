namespace Business.Services.PostServices
{
    /// <summary>
    /// Represents a set of methods to validate post contents.
    /// </summary>
    public class PostValidator : ServiceBase, IPostValidator
    {
        /// <inheritdoc />
        public bool IsValid(string content)
        {
            return false;
        }
    }
}
