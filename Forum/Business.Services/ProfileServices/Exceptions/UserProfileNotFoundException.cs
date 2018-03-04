using System;
using System.Runtime.Serialization;

namespace Business.Services.ProfileServices.Exceptions
{
    /// <summary>
    /// The exception that is throw when the specified user profile cannot be found.
    /// </summary>
    [Serializable]
    public class UserProfileNotFoundException : Exception
    {
        /// <inheritdoc />
        public UserProfileNotFoundException()
        {

        }

        /// <inheritdoc />
        public UserProfileNotFoundException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public UserProfileNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected UserProfileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
