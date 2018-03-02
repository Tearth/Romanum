using System;
using System.Runtime.Serialization;

namespace App.Services.AuthServices.Exceptions
{
    [Serializable]
    public class UserNameAlreadyExistsException : Exception
    {
        public UserNameAlreadyExistsException()
        {

        }

        public UserNameAlreadyExistsException(string message) : base(message)
        {

        }

        public UserNameAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {

        }

        protected UserNameAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
