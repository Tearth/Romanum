using System;
using System.Runtime.Serialization;

namespace Business.Services.ConfigServices.Exceptions
{
    [Serializable]
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException()
        {

        }

        public KeyNotFoundException(string message) : base(message)
        {

        }

        public KeyNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        protected KeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
