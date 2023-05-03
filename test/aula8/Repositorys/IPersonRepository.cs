using aula8.Models;
using System.Collections.Specialized;

namespace aula8.Repositorys
{
    public interface IPersonRepository:IRepository<Person>
    {
       Person Disable(long id);
       List<Person> FindByName(string firstName,string secondName);
    }
}
