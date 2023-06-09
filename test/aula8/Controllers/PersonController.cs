using aula8.Data.VO;
using aula8.Hypermedia.Filters;
using aula8.Models;
using aula8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aula8.Controllers
{
    [ApiVersion("1")]
    [ApiController]
   [Authorize("Bearer")]
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
        [TypeFilter (typeof(HyperMediaFilter))]
        public IActionResult GetAll()
        {
            return Ok(_personRepository.FindAll());
        }
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetUnique(long id)
        {
            var person = _personRepository.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        [HttpGet("findPersonByName")]
        [ProducesResponseType(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetUnique([FromQuery]string? firstName, [FromQuery]string? lastName)
        {
            var person = _personRepository.FindByName(firstName,lastName);
            if (person == null) return NotFound();
            return Ok(person);
        }
        [HttpPatch("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(long id)
        {
            var person = _personRepository.Disable(id);
            return Ok(person);
        }
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personRepository.Create(person));
        }
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personRepository.Update(person));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personRepository.Delete(id);
            return NoContent();
        }
    }
}