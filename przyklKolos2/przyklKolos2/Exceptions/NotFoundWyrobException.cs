using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace przyklKolos2.Exceptions
{
    public class NotFoundWyrobException : Exception
    {
        public NotFoundWyrobException()
        {
        }

        public NotFoundWyrobException(string message) : base(message)
        {
        }

        public NotFoundWyrobException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundWyrobException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
