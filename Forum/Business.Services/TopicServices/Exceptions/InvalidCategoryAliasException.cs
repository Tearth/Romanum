using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.TopicServices.Exceptions
{
    [Serializable]
    public class InvalidCategoryAliasException : Exception
    {
        public InvalidCategoryAliasException()
        {

        }

        public InvalidCategoryAliasException(string message) : base(message)
        {

        }

        public InvalidCategoryAliasException(string message, Exception inner) : base(message, inner)
        {

        }

        protected InvalidCategoryAliasException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
