using aula8.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula8.Models
{
    [Table("person")]
    public class Person:BaseEntity
    {
        [Column("FIRST_NAME")]
        public string FirstName { get; set; }
        [Column("LAST_NAME")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("GENDER")]
        public string Gender { get; set; }
    }
}
