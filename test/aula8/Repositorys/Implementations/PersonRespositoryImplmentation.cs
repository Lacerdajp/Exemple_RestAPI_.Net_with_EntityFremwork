using aula8.Models;
using aula8.Models.Context;
using aula8.Repositorys.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace aula8.Repositorys.Implementations
{
    public class PersonRespositoryImplmentation : GenericRepository<Person>,IPersonRepository
    {
        public PersonRespositoryImplmentation(SqlContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.id.Equals(id))) return null;
            var user = _context.Persons.SingleOrDefault(p => p.id.Equals(id));
            if (user != null)
            {
                user.Enabled=false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }
    }
}
