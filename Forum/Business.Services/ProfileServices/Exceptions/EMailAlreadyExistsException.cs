using System;
using System.Runtime.Serialization;

namespace Business.Services.ProfileServices.Exceptions
{
    /// <summary>
    /// The exception that is throw when the specified e-mail address already exists
    /// (and cannot be added again on example).
    /// </summary>
    [Serializable]
    public class EMailAlreadyExistsException : Exception
    {
        /// <inheritdoc />
        public EMailAlreadyExistsException()
        {

        }

        /// <inheritdoc />
        public EMailAlreadyExistsException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public EMailAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected EMailAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
