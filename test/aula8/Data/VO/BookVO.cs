using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace aula8.Data.VO
{
    public class BookVO
    {
        [JsonPropertyOrder(-2)]
        public long id { get; set; }

        public string autor { get; set; }
        [JsonPropertyOrder(-1)]
        public string titulo { get; set; }
        public decimal valor { get; set; }
        public DateTime data { get; set; }
    }
}
