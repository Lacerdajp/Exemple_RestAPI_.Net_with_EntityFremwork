using aula8.Data.VO;
using aula8.Hypermedia.Filters;
using aula8.Services;
using Microsoft.AspNetCore.Mvc;

namespace aula8.Controllers
{  
    [ApiVersion("1")]
    [ApiController]
    [Route("[controller]/v{version:ApiVersion}")]
    public class BookController:ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookServices _bookServices;
        public BookController(ILogger<BookController> logger, IBookServices bookServices)
        {
            _logger = logger;
            _bookServices = bookServices;
        }
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAll()
        {
            return Ok(_bookServices.FindAllBooks());
        }
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetUnique(int  id)
        {
            var book = _bookServices.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookServices.Create(book));
        }
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookServices.Update(book));
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _bookServices.Delete(id);
            return NoContent();
        }
    }
}
