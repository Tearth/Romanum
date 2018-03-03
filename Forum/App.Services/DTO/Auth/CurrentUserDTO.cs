namespace App.Services.DTO.Auth
{
    /// <summary>
    /// Represents the current user information.
    /// </summary>
    public class CurrentUserDTO
    {
        /// <summary>
        /// Gets or sets the current user ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the current username.
        /// </summary>
        public string Name { get; set; }
    }
}
