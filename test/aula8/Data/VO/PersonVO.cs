using aula8.Hypermedia;
using aula8.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula8.Data.VO
{
    public class PersonVO:ISupportHyperMedia
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool Enabled { get; set; }
        public List<HyperMediaLink> Links {get; set; }=new List<HyperMediaLink>();
    }
}
