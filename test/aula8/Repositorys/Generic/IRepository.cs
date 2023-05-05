using aula8.Models;
using aula8.Models.Base;

namespace aula8.Repositorys
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exist(long id);

        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
