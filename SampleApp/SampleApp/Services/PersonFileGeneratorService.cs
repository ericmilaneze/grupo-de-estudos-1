using SampleApp.Interfaces;
using System;
using System.IO;
using System.IO.Abstractions;

namespace SampleApp.Services
{
    public class PersonFileGeneratorService : IPersonFileGeneratorService
    {
        private readonly IFileSystem fileSystem;
        private readonly IPersonRepository personRepository;
        private readonly IFileEncryptor fileEncryptor;
        
        public PersonFileGeneratorService(IFileSystem fileSystem, IPersonRepository personRepository, IFileEncryptor fileEncryptor)
        {
            this.fileSystem = fileSystem;
            this.personRepository = personRepository;
            this.fileEncryptor = fileEncryptor;
        }

        public void GenerateFile(string fileName)
        {
            WritePersonsToFile(fileName);
            EncryptFile(fileName);
        }

        private void WritePersonsToFile(string fileName)
        {
            string decimalToString(decimal input) => $"{Math.Truncate(Math.Round(input, 2) * 100)}";

            using (var file = fileSystem.File.Open(fileName, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(file))
            {
                foreach (var person in personRepository.GetAll())
                {
                    writer.Write(person.Name?.ToUpper().PadRight(10, ' '));
                    writer.Write(person.Birthday.ToString("yyyyMMdd"));
                    writer.Write(person.Profession?.ToUpper().PadRight(10, ' '));
                    writer.Write(decimalToString(person.Patrimony).PadLeft(10, '0'));
                    writer.WriteLine();
                }
            }
        }

        private void EncryptFile(string fileName)
        {
            var file = fileSystem.FileInfo.FromFileName(fileName);
            fileEncryptor.EncryptFile(file);
        }
    }
}
