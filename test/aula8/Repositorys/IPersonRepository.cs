using aula8.Models;

namespace aula8.Repositorys
{
    public interface IPersonRepository:IRepository<Person>
    {
       Person Disable(long id);
    }
}
