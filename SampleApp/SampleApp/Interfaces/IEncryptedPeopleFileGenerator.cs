using System.Collections.Generic;

namespace SampleApp.Interfaces
{
    public interface IEncryptedPeopleFileGenerator
    {
        void GenerateEncryptedFile(string fileName, ICollection<Person> people);
    }
}