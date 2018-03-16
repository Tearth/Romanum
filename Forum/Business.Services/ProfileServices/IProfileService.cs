using Business.Services.DTO.Profile;
using Business.Services.ProfileServices.Exceptions;

namespace Business.Services.ProfileServices
{
    /// <summary>
    /// Represents an interface for profile service.
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Checks if the user with the specified name exists.
        /// </summary>
        /// <param name="userName">The username to check.</param>
        /// <returns>true if the specified username exists, otherwise false.</returns>
        bool UserNameExists(string userName);

        /// <summary>
        /// Checks if the specified email exists.
        /// </summary>
        /// <param name="email">The email to check</param>
        /// <returns>True if the specified email exists, otherwise false.</returns>
        bool EMailExists(string email);

        /// <summary>
        /// Checks if the profile with the specified id exists.
        /// </summary>
        /// <param name="id">The profile id to check</param>
        /// <returns>True if the profile with the specified id exists, otherwise false.</returns>
        bool ProfileExists(int id);

        /// <summary>
        /// Changes profile data to the specified in the parameter.
        /// </summary>
        /// <param name="id">The profile id.</param>
        /// <param name="profileData">The new profile data.</param>
        /// <exception cref="UserProfileNotFoundException">Thrown when a profile with the specified id doesn't exists.</exception>
        /// <exception cref="EMailAlreadyExistsException">thrown when the new email already exists.</exception>
        void ChangeProfile(int id, ChangeProfileDTO profileData);

        /// <summary>
        /// Gets the profile with the specified id.
        /// </summary>
        /// <param name="id">The profile id to get.</param>
        /// <exception cref="UserProfileNotFoundException">Thrown when a profile with the specified id doesn't exists.</exception>
        /// <returns>The profile with the specified id.</returns>
        ProfileDTO GetProfileByUserID(int id);
    }
}
