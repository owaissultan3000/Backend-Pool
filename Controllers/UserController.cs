using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using carpool.Models;
using carpool.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace carpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;  

        public UserController(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost]  
        [Route("UserLogin")]  
        public async Task<IActionResult> Login([FromBody] UserLogin model)  
        {  
            string key ="Roses are red Violets are blue, White wine costs less, Than dinner for two. xDDDD" ;
            var user = await _userService.GetUser(model.UserEmail);  
            
            if (user != null && BCrypt.Net.BCrypt.Verify(model.UserPassword, user.Passwords) == true)  
            {  
                // var userRoles = await userManager.GetRolesAsync(user);  
  
            // var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey   = Encoding.ASCII.GetBytes(key)  ;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim (ClaimTypes.Name,
                               model.UserEmail)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);  
                return Ok(new  
                {  
                    token = new JwtSecurityTokenHandler().WriteToken(token),  
                    expiration = token.ValidTo  
                });  
            }  
             return Unauthorized();  
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

        [HttpPost("UserRegistration")]
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

        // [HttpPut("UpdateUser")]
        // public async Task<IActionResult> UpdateUser([FromBody]UserModel user)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             await _userService.UpdateUser(user);

        //             return Ok();
        //         }
        //         catch (Exception ex)
        //         {
        //             if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
        //             {
        //                 return NotFound();
        //             }

        //             return BadRequest();
        //         }
        //     }

        //     return BadRequest();
        // }
        
    }
}