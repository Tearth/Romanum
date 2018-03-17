namespace Business.Services.DTO.Avatar
{
    /// <summary>
    /// Represents the new user avatar data.
    /// </summary>
    public class ChangedAvatarDTO
    {
        /// <summary>
        /// Gets or sets the new avatar type.
        /// </summary>
        public AvatarTypeDTO Type { get; set; }

        /// <summary>
        /// Gets or sets the new avatar source.
        /// </summary>
        public string Source { get; set; }
    }
}
