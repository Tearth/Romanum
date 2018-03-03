using System;
using System.Runtime.Serialization;

namespace App.Services.AuthServices.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the specified user is not logged in.
    /// </summary>
    [Serializable]
    public class UserNotLoggedInException : Exception
    {
        /// <inheritdoc />
        public UserNotLoggedInException()
        {

        }

        /// <inheritdoc />
        public UserNotLoggedInException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public UserNotLoggedInException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected UserNotLoggedInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
