namespace App.Services.DTO.Auth
{
    /// <summary>
    /// Represents a registration parameters.
    /// </summary>
    public class RegistrationDTO
    {
        /// <summary>
        /// Gets or sets the new username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the new username password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the new user e-mail.
        /// </summary>
        public string EMail { get; set; }
    }
}
