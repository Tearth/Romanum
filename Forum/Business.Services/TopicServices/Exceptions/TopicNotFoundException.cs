using System;
using System.Runtime.Serialization;

namespace Business.Services.TopicServices.Exceptions
{
    /// <summary>
    /// The exception that is throw when the specified topic cannot be found.
    /// </summary>
    [Serializable]
    public class TopicNotFoundException : Exception
    {
        /// <inheritdoc />
        public TopicNotFoundException()
        {

        }

        /// <inheritdoc />
        public TopicNotFoundException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public TopicNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected TopicNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
