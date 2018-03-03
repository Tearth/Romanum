using App.Services.DTO.Auth;

namespace App.Services.AuthServices.Security
{
    /// <summary>
    /// Represents an interface for WebSecurity wrapper which is easier to do unit tests.
    /// </summary>
    public interface IWebSecurityWrapper
    {
        /// <summary>
        /// Creates user with the specified parameters.
        /// </summary>
        /// <param name="user">The user to add.</param>
        void CreateUser(RegistrationDTO user);

        /// <summary>
        /// Checks if the specified username exists in the database.
        /// </summary>
        /// <param name="name">The username to check.</param>
        /// <returns>True if the specified username exists, otherwise false.</returns>
        bool UserExists(string name);

        /// <summary>
        /// Checks if the current user is logged in.
        /// </summary>
        /// <returns>True if the current user is logged in, otherwise false.</returns>
        bool IsUserLoggedIn();

        /// <summary>
        /// Log ins user with the specified username and password.
        /// </summary>
        /// <param name="data">The log in parameters.</param>
        /// <returns>True if the user has been successfully logged in, otherwise false.</returns>
        bool LogIn(LogInDTO data);

        /// <summary>
        /// Log outs the current user.
        /// </summary>
        void LogOut();

        /// <summary>
        /// Changes password for the specified user.
        /// </summary>
        /// <param name="data">The change password parameters.</param>
        /// <returns>True if the password has been successfully changes, otherwise false.</returns>
        bool ChangePassword(ChangePasswordDTO data);

        /// <summary>
        /// Gets the current user information.
        /// </summary>
        /// <returns>The current user information if logged in, otherwise null.</returns>
        CurrentUserDTO GetCurrentUser();
    }
}
