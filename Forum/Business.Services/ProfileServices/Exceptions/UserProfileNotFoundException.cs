using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProfileServices.Exceptions
{
    [Serializable]
    public class UserProfileNotFoundException : Exception
    {
        public UserProfileNotFoundException()
        {

        }

        public UserProfileNotFoundException(string message) : base(message)
        {

        }

        public UserProfileNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        protected UserProfileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
