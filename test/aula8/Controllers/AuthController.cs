using aula8.Data.VO;
using aula8.Hypermedia.Filters;
using aula8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aula8.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:ApiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginServices _loginServices;

        public AuthController(ILoginServices loginServices)
        {
           _loginServices = loginServices;
        }
        [HttpPost]

        [Route("singin")]
        public IActionResult Singin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var token = _loginServices.ValidationCredentials(user);
            return token == null ? Unauthorized() : Ok(token);
        }
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO is null) return BadRequest("Invalid client request");
            var token = _loginServices.ValidationCredentials(tokenVO);
            return token == null ? BadRequest("Invalid client request") : Ok(token);
        }
        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result =_loginServices.RevokeToken(username);
            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }

    }
}
