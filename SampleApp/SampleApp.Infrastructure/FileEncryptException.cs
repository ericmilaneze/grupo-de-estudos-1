using System;
using System.Runtime.Serialization;

namespace SampleApp.Infrastructure
{
    [Serializable]
    internal class FileEncryptException : Exception
    {
        public FileEncryptException()
        {
        }

        public FileEncryptException(string message) : base(message)
        {
        }

        public FileEncryptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileEncryptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
