using Dapper;
using SampleApp.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SampleApp.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            using (var connection = new SqlConnection("Data Source=.; Initial Catalog=TestDB; Integrated Security=True;"))
            {
                return connection.Query<Person>("SELECT Name, Birthday, Profession, Patrimony FROM dbo.Person");
            }
        }
    }
}
