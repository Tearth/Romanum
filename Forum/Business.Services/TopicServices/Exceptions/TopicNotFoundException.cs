using System;
using System.Runtime.Serialization;

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
