using System.Collections.Generic;
using SampleApp.Interfaces;

namespace SampleApp.Services
{
    public class EncryptedPeopleFileGenerator : IEncryptedPeopleFileGenerator
    {
        private readonly IFileEncryptor fileEncryptor;
        private readonly PeopleFileGenerator peopleFileGenerator;

        public EncryptedPeopleFileGenerator(IFileEncryptor fileEncryptor, PeopleFileGenerator peopleFileGenerator)
        {
            this.fileEncryptor = fileEncryptor ?? throw new System.ArgumentNullException(nameof(fileEncryptor));
            this.peopleFileGenerator = peopleFileGenerator ?? throw new System.ArgumentNullException(nameof(peopleFileGenerator));
        }

        public void GenerateEncryptedFile(string fileName, ICollection<Person> people)
        {
            var fileInfo = peopleFileGenerator.GenerateFile(fileName, people);
            fileEncryptor.EncryptFile(fileInfo);
        }
    }
}