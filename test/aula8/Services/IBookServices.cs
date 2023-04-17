using aula8.Data.VO;

namespace aula8.Services
{
    public interface IBookServices
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        List<BookVO> FindAllBooks();
        void Delete(int id);
        BookVO FindById(int id);
    }
}
