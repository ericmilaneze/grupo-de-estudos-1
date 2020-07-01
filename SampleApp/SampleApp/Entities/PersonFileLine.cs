using System;
using System.Text;

namespace SampleApp.Entities
{
    public class PersonFileLine
    {
        private Person person;

        public string Name =>
            person.Name?.ToUpper().PadRight(10, ' ');

        public string Birthday =>
            person.Birthday.ToString("yyyyMMdd");

        public string Profession =>
            person.Profession?.ToUpper().PadRight(10, ' ');

        public string Patrimony =>
            decimalToString(person.Patrimony).PadLeft(10, '0');

        private PersonFileLine(Person person)
        {
            this.person = person;
        }

        public static PersonFileLine FromPerson(Person person)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person));
            
            return new PersonFileLine(person);
        }

        public string WriteLine() =>
            new StringBuilder()
                .Append(Name)
                .Append(Birthday)
                .Append(Profession)
                .Append(Patrimony)
                .ToString();

        private string decimalToString(decimal input) => 
            $"{Math.Truncate(Math.Round(input, 2) * 100)}";
    }
}