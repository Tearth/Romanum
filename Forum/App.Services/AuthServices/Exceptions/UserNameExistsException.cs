using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AuthServices.Exceptions
{
    [Serializable]
    public class UserNameExistsException : Exception
    {
        public UserNameExistsException()
        {

        }

        public UserNameExistsException(string message) : base(message)
        {

        }

        public UserNameExistsException(string message, Exception inner) : base(message, inner)
        {

        }

        protected UserNameExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
