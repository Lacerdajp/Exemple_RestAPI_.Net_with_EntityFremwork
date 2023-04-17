using aula8.Models;

namespace aula8.Repositorys
{
    public interface IRepository
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exist(long id);
    }
}
