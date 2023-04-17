using aula8.Models;
using aula8.Models.Context;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace aula8.Repositorys.Implementations
{
    public class PersonRespositoryImplmentation : IRepository
    {
        private SqlContext _context;

        public PersonRespositoryImplmentation(SqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList() ;
        }

        public Person FindByID(long id)
        {
              return _context.Persons.SingleOrDefault(p=>p.id.Equals(id)) ;
        }

        public Person Update(Person person)
        {
            if (!Exist(person.id)) return null;
            var result = _context.Persons.SingleOrDefault(p => p.id.Equals(person.id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
            } return person;
        }

        public bool Exist(long id)
        {
            return _context.Persons.Any(p => p.id.Equals(id));
        }
    }
}
