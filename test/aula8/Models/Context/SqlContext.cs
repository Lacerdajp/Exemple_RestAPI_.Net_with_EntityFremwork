using Microsoft.EntityFrameworkCore;

namespace aula8.Models.Context
{
    public class SqlContext:DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<User> users { get; set; }
    }
}
