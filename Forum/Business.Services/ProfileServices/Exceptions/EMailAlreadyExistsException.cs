using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
