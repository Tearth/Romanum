using System;
using System.Runtime.Serialization;

namespace App.Services.AuthServices.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the specified user name not exists.
    /// </summary>
    [Serializable]
    public class UserNameNotExistsException : Exception
    {
        /// <inheritdoc />
        public UserNameNotExistsException()
        {

        }

        /// <inheritdoc />
        public UserNameNotExistsException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public UserNameNotExistsException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected UserNameNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
