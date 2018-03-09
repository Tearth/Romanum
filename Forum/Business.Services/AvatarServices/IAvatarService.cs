using Business.Services.DTO.Avatar;

namespace Business.Services.AvatarServices
{
    /// <summary>
    /// Represents an interface for avatar service.
    /// </summary>
    public interface IAvatarService
    {
        /// <summary>
        /// Gets the user avatar information by ID.
        /// </summary>
        /// <param name="userID">The user avatar.</param>
        /// <returns>The avatar information.</returns>
        AvatarDTO GetUserAvatar(int userID);

        /// <summary>
        /// Sets the user avatar to default.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        void SetUserAvatarToDefault(int userID);

        /// <summary>
        /// Sets the user avatar to the specified in parameter.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="type">The avatar type.</param>
        /// <param name="imageSource">The avatar source.</param>
        void SetUserAvatar(int userID, AvatarTypeDTO type, string imageSource);
    }
}
