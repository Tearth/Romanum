using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.CategoryServices.Exceptions
{
    [Serializable]
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException()
        {

        }

        public CategoryNotFoundException(string message) : base(message)
        {

        }

        public CategoryNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }

        protected CategoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
