using System;
using System.Runtime.Serialization;

namespace Business.Services.CategoryServices.Exceptions
{
    [Serializable]
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException()
        {

        }

        public CategoryNotFoundException(string message) : base(message)
        {

        }

        public CategoryNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        protected CategoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
