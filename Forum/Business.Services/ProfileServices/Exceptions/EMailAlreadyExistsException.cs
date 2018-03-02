using System;
using System.Runtime.Serialization;

namespace Business.Services.ProfileServices.Exceptions
{
    [Serializable]
    public class EMailAlreadyExistsException : Exception
    {
        public EMailAlreadyExistsException()
        {

        }

        public EMailAlreadyExistsException(string message) : base(message)
        {

        }

        public EMailAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {

        }

        protected EMailAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
