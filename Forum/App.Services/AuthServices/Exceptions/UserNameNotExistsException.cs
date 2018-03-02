using System;
using System.Runtime.Serialization;

namespace App.Services.AuthServices.Exceptions
{
    [Serializable]
    public class UserNameNotExistsException : Exception
    {
        public UserNameNotExistsException()
        {

        }

        public UserNameNotExistsException(string message) : base(message)
        {

        }

        public UserNameNotExistsException(string message, Exception inner) : base(message, inner)
        {

        }

        protected UserNameNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
