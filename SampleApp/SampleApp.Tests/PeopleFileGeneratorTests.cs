using Moq;
using NUnit.Framework;
using SampleApp.Interfaces;
using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace SampleApp.Tests
{
    public class PeopleFileGeneratorTests
    {
        private readonly ICollection<Person> people = new[]
        {
            new Person { Name = "John", Birthday = new DateTime(1989, 10, 18), Profession = "Developer", Patrimony = 125000.56M },
            new Person { Name = "Anne", Birthday = new DateTime(1987, 11, 11), Profession = "Lawyer", Patrimony = 270801.12M },
            new Person { Name = "Paul", Birthday = new DateTime(1959, 7, 13), Profession = "Doctor", Patrimony = 173185.04M }
        };
        private readonly string fileName = @"C:\temp\teste.txt";

        private MockFileSystem fileSystemMock;
        private PeopleFileGenerator sut;
        
        [SetUp]
        public void Setup()
        {
            SetupMocks();
            sut = new PeopleFileGenerator(fileSystemMock);
        }

        private void SetupMocks()
        {
            fileSystemMock = new MockFileSystem();
        }

        [Test]
        public void ShouldGenerateValidFile()
        {
            //Act
            sut.GenerateFile(fileName, people);

            //Check
            var generatedFile = fileSystemMock.GetFile(fileName);
            var lines = generatedFile.TextContents.SplitLines();

            Assert.AreEqual(3, lines.Length);
            Assert.AreEqual("JOHN      19891018DEVELOPER 0012500056", lines[0]);
            Assert.AreEqual("ANNE      19871111LAWYER    0027080112", lines[1]);
            Assert.AreEqual("PAUL      19590713DOCTOR    0017318504", lines[2]);
        }
    }
}