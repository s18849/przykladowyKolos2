using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace przyklKolos2.Exceptions
{
    public class NotFoundClientException : Exception
    {
        public NotFoundClientException()
        {
        }

        public NotFoundClientException(string message) : base(message)
        {
        }

        public NotFoundClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
