namespace Business.Services.DTO.Profile
{
    /// <summary>
    /// Represents the change profile information.
    /// </summary>
    public class ChangeProfileDTO
    {
        /// <summary>
        /// Gets or sets the new e-mail.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets the new city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the new additional user information.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Gets or sets the new footer.
        /// </summary>
        public string Footer { get; set; }
    }
}
