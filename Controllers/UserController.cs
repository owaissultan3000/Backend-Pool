using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> AllUsers()
        {
            // return Ok(_userService.AllUsers());
             try
            {
                var users = await _userService.AllUsers();
                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception )
            {
                return BadRequest();
            }
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateUser([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
            {
                 try
                {
                    var tempuser = await _userService.CreateUser(user);
                    if (tempuser != null)
                    {
                        return Ok(tempuser);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }


            }
            else return BadRequest();
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _userService.GetUser(email);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string email)
        {
             string result = "";

            if (email == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _userService.DeleteUser(email);
                if (result == "" || result == null)
                {
                    return NotFound();
                }
                return Ok(email+" Deleted Successfully");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateUser(user);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
        
    }
}