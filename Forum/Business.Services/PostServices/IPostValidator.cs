namespace Business.Services.PostServices
{
    /// <summary>
    /// Represents an interface for post validator.
    /// </summary>
    public interface IPostValidator
    {
        /// <summary>
        /// Checks if the post content doesn't contains dangerous tags like script or so.
        /// </summary>
        /// <param name="content">The post content to check.</param>
        /// <returns>True if the post content is valid and can be stored in database, otherwise false.</returns>
        bool IsValid(string content);
    }
}
