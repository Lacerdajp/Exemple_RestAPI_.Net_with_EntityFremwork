using aula8.Models;

namespace aula8.Repositorys
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        List<Book> findAll();
        Book findById(int id);
        void deleteById(int id);
        bool Exist(long id);

    }
}
