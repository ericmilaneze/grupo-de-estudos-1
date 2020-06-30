using System.IO.Abstractions;

namespace SampleApp.Interfaces
{
    public interface IFileEncryptor
    {
        void EncryptFile(IFileInfo file);
    }
}
