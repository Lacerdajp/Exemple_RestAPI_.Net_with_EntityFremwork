using aula8.Models;
using aula8.Models.Base;
using aula8.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace aula8.Repositorys.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
      public SqlContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(SqlContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public T Create(T item)
        {
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Delete(long id)
        {
            var result = _dbSet.SingleOrDefault(p => p.id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dbSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

       

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public T FindByID(long id)
        {
            return _dbSet.SingleOrDefault(p => p.id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exist(item.id)) return null;
            var result = _dbSet.SingleOrDefault(p => p.id.Equals(item.id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else { return null; }
            return item;
        } public bool Exist(long id)
        {
            return _dbSet.Any(p => p.id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dbSet.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using(var connection=_context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command=connection.CreateCommand())
                {
                    command.CommandText = query;
                    result=command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }
    }
}
