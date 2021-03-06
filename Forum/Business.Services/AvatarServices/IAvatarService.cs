﻿using Business.Services.DTO.Avatar;
using Business.Services.ProfileServices.Exceptions;
using DataAccess.Entities;

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
        /// <exception cref="UserProfileNotFoundException">Thrown when a user with the specified id doesn't exists.</exception>
        /// <returns>The avatar information.</returns>
        AvatarDTO GetUserAvatar(int userID);

        /// <summary>
        /// Sets the user avatar to default.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <exception cref="UserProfileNotFoundException">Thrown when a user with the specified id doesn't exists.</exception>
        void SetUserAvatarToDefault(int userID);

        /// <summary>
        /// Sets the user avatar to the specified in parameter.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="changedAvatar">The changed avatar.</param>
        /// <exception cref="UserProfileNotFoundException">Thrown when a user with the specified id doesn't exists.</exception>
        void SetUserAvatar(int userID, ChangedAvatarDTO changedAvatar);

        /// <summary>
        /// Checks if the uploaded avatar has correct mime type (to avoid uploading some weird files
        /// like php scripts etc.).
        /// </summary>
        /// <param name="mimeType">The mime type to check.</param>
        /// <returns>True if the mime type is allowed, otherwise false.</returns>
        bool CheckIfMimeTypeIsValid(string mimeType);
    }
}
