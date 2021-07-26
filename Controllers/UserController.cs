using carpool.Models;
using carpool.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace carpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("AllUsers")]
        public IActionResult AllUsers()
        {
            return Ok(_userService.AllUsers());
        }

        [HttpPost("AddUser")]
        public IActionResult CreateUser(UserModel user)
        {
            return Ok(_userService.CreateUser(user));
        }
        
    }
}