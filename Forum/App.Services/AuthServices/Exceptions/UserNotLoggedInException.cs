using System;
using System.Runtime.Serialization;

namespace App.Services.AuthServices.Exceptions
{
    [Serializable]
    public class UserNotLoggedInException : Exception
    {
        public UserNotLoggedInException()
        {

        }

        public UserNotLoggedInException(string message) : base(message)
        {

        }

        public UserNotLoggedInException(string message, Exception inner) : base(message, inner)
        {

        }

        protected UserNotLoggedInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
