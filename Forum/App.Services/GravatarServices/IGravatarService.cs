namespace App.Services.GravatarServices
{
    /// <summary>
    /// Represents an interface for Gravatar service.
    /// </summary>
    public interface IGravatarService
    {
        /// <summary>
        /// Gets the Gravatar link to user avatar.
        /// </summary>
        /// <param name="userEMail">The user e-mail.</param>
        /// <returns>The link to the Gravatar avatar.</returns>
        string GetGravatarLink(string userEMail);

        /// <summary>
        /// Gets the Gravatar hash for the specified user e-mail.
        /// </summary>
        /// <param name="userEMail">The user e-mail.</param>
        /// <returns>The gravatar hash which will be used to display user avatar.</returns>
        string GetGravatarHash(string userEMail);
    }
}
