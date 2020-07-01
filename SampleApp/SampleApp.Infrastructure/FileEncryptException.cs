using System;
using System.Runtime.Serialization;

namespace SampleApp.Infrastructure
{
    [Serializable]
    internal class FileEncryptException : Exception
    {
        public FileEncryptException(string message) : base(message)
        {
        }
    }
}
