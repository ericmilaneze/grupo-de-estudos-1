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
                process.StartInfo = GetStartInfoParameters(file.FullName);
                process.Start();
                process.WaitForExit();
                CheckExitCode(process);
            }
        }

        private ProcessStartInfo GetStartInfoParameters(string fileFullName) =>
            new ProcessStartInfo()
            {
                FileName = "pgp", //https://docs.broadcom.com/doc/pgp-command-line-en
                Arguments = $"--encrypt {fileFullName} --recipient FileReceiverCommonName --output {fileFullName}",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };
        
        private static void CheckExitCode(Process process)
        {
            if (process.ExitCode != 0)
                throw new FileEncryptException($"Failure to encrypt file, exit code is {process.ExitCode}");
        }
    }
}