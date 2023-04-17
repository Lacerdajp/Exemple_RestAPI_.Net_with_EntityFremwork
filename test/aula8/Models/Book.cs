using aula8.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula8.Models
{
    [Table("books")]
    public class Book:BaseEntity
    {
        [Column("autor")]
        public string autor { get; set; }
        [Column("titulo")]
        public string titulo { get; set; }
        [Column("valor")]
        public decimal valor { get; set; }
        [Column("data")]
        public DateTime data { get; set; }

    }
}
