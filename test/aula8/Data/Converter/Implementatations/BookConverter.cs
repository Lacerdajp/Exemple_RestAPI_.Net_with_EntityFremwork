using aula8.Data.Converter.Contract;
using aula8.Data.VO;
using aula8.Models;

namespace aula8.Data.Converter.Implementatations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                id= origin.id,
                autor=origin.autor,
                data=origin.data,
                titulo=origin.titulo,
                valor=origin.valor,
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                id = origin.id,
                autor = origin.autor,
                data = origin.data,
                titulo = origin.titulo,
                valor = origin.valor,
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
