using System;
using System.Runtime.Serialization;

namespace App.Services.AuthServices.Exceptions
{
    /// <summary>
    /// The exception that is throw when the specified user name already exists
    /// (and can't be added for example).
    /// </summary>
    [Serializable]
    public class UserNameAlreadyExistsException : Exception
    {
        /// <inheritdoc />
        public UserNameAlreadyExistsException()
        {

        }

        /// <inheritdoc />
        public UserNameAlreadyExistsException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public UserNameAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected UserNameAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
