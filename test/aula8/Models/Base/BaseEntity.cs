using System.ComponentModel.DataAnnotations.Schema;

namespace aula8.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long id { get; set; }
    }
}
