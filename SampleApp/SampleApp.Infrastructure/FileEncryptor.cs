using SampleApp.Interfaces;
using System.Diagnostics;
using System.IO.Abstractions;

namespace SampleApp.Infrastructure
{
    public class FileEncryptor : IFileEncryptor
    {
        public void EncryptFile(IFileInfo file)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "pgp"; //https://docs.broadcom.com/doc/pgp-command-line-en
                process.StartInfo.Arguments = $"--encrypt {file.FullName} --recipient FileReceiverCommonName --output {file.FullName}";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;

                process.Start();
                
                process.WaitForExit();

                if (process.ExitCode != 0)
                    throw new FileEncryptException($"Failure to encrypt file, exit code is {process.ExitCode}");
            }
        }
    }
}