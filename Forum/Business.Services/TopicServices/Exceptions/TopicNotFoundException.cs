using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.TopicServices.Exceptions
{
    [Serializable]
    public class TopicNotFoundException : Exception
    {
        public TopicNotFoundException()
        {

        }

        public TopicNotFoundException(string message) : base(message)
        {

        }

        public TopicNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        protected TopicNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
