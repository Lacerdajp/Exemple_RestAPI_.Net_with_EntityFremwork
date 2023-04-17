using aula8.Models;
using aula8.Models.Context;
using System;

namespace aula8.Repositorys.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private SqlContext _context;
        public BookRepositoryImplementation(SqlContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return book;
        }

        public void deleteById(int id)
        {
            var result = _context.books.SingleOrDefault(p => p.id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public List<Book> findAll()
        {
            return _context.books.ToList();
        }

        public Book findById(int id)
        {
            return _context.books.SingleOrDefault(p => p.id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exist(book.id)) return null;
            var result = _context.books.SingleOrDefault(p => p.id.Equals(book.id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return book;
        }

        public bool Exist(long id)
        {
            return _context.books.Any(p => p.id.Equals(id));
        }
    }
}
