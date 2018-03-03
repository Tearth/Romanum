namespace App.Services.DTO.Auth
{
    /// <summary>
    /// Represents a change password parameters.
    /// </summary>
    public class ChangePasswordDTO
    {
        /// <summary>
        /// Gets or sets the username for which the password will be changes.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        public string NewPassword { get; set; }
    }
}
