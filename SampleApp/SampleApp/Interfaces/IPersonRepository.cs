using System.Collections.Generic;

namespace SampleApp.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
    }
}