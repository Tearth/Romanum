namespace Business.Services.DTO.Profile
{
    /// <summary>
    /// Represents the user's most active category information.
    /// </summary>
    public class UserMostActiveCategoryDTO
    {
        /// <summary>
        /// Gets or sets the user's most active category name.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the user's most active category alias.
        /// </summary>
        public string CategoryAlias { get; set; }
    }
}
