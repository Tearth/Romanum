using System;
using System.Runtime.Serialization;

namespace Business.Services.ConfigServices.Exceptions
{
    /// <summary>
    /// The exception that is throw when the specified key cannot be found.
    /// </summary>
    [Serializable]
    public class KeyNotFoundException : Exception
    {
        /// <inheritdoc />
        public KeyNotFoundException()
        {

        }

        /// <inheritdoc />
        public KeyNotFoundException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public KeyNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected KeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
