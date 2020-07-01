using System.Collections.Generic;
using System.IO.Abstractions;

namespace SampleApp.Interfaces
{
    public interface IPeopleFileGeneratorService
    {
        IFileInfo GenerateFile(string fileName, ICollection<Person> people);
    }
}