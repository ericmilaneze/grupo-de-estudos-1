using SampleApp.Entities;
using SampleApp.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace SampleApp.Services
{
    public class PeopleFileGenerator : IPeopleFileGeneratorService
    {
        private readonly IFileSystem fileSystem;
        
        public PeopleFileGenerator(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public IFileInfo GenerateFile(string fileName, ICollection<Person> people)
        {
            using (var file = fileSystem.File.Open(fileName, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(file))
                foreach (var person in people)
                    WriteFile(writer, person);

            return fileSystem.FileInfo.FromFileName(fileName);
        }

        private void WriteFile(StreamWriter writer, Person person)
        {
            string fileLine = GetFileLine(person);
            writer.WriteLine(fileLine);
        }

        private static string GetFileLine(Person person)
        {
            var personWrapper = PersonFileLine.FromPerson(person);
            return personWrapper.WriteLine();
        }
    }
}
