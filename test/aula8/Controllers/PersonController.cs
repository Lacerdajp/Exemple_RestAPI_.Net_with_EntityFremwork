using aula8.Data.VO;
using aula8.Models;
using aula8.Services;
using Microsoft.AspNetCore.Mvc;

namespace aula8.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonServices _personRepository;
        public PersonController(ILogger<PersonController> logger, IPersonServices personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personRepository.FindAll());
        }
        [HttpGet("id")]
        public IActionResult GetUnique(long id)
        {
            var person = _personRepository.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personRepository.Create(person));
        }
        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personRepository.Update(person));
        }
        [HttpDelete("id")]
        public IActionResult Delete(long id)
        {
            _personRepository.Delete(id);
            return NoContent();
        }
    }
}