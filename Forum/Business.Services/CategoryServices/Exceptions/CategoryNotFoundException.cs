using System;
using System.Runtime.Serialization;

namespace Business.Services.CategoryServices.Exceptions
{
    /// <summary>
    /// The exception that is throw when the specified category name cannot be found.
    /// </summary>
    [Serializable]
    public class CategoryNotFoundException : Exception
    {
        /// <inheritdoc />
        public CategoryNotFoundException()
        {

        }

        /// <inheritdoc />
        public CategoryNotFoundException(string message) : base(message)
        {

        }

        /// <inheritdoc />
        public CategoryNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <inheritdoc />
        protected CategoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
