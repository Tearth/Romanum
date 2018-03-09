namespace Business.Services.DTO.Avatar
{
    /// <summary>
    /// Represents the user avatar data.
    /// </summary>
    public class AvatarDTO
    {
        /// <summary>
        /// Gets or sets the avatar type.
        /// </summary>
        public AvatarTypeDTO Type { get; set; }

        /// <summary>
        /// Gets or sets the avatar source.
        /// </summary>
        public string Source { get; set; }
    }
}
