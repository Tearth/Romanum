namespace App.Services.DTO.Auth
{
    /// <summary>
    /// Represents a log in parameters.
    /// </summary>
    public class LogInDTO
    {
        /// <summary>
        /// Gets or sets the username which is logging in.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the flag indicates whether the user should be always logged in or not.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
