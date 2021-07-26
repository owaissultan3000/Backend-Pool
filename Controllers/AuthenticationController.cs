using carpool.Models;
using carpool.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace carpool.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController:ControllerBase
    {
        public readonly IJwtAuthentication _jwtAuthentication;
        public AuthenticationController(IJwtAuthentication jwtAuthentication)
        {
            _jwtAuthentication = jwtAuthentication;
        }

        [AllowAnonymous]
        [HttpPost("UserAuthentication")]
        public IActionResult Authenticate([FromBody] UserLogin userLogin)
        {
            var token=_jwtAuthentication.Authenticate(userLogin.UserEmail, userLogin.UserPassword);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}