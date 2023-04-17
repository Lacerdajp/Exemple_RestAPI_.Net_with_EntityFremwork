using System.ComponentModel.DataAnnotations.Schema;

namespace aula8.Data.VO
{
    public class PersonVO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
