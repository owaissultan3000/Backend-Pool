using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using carpool.Models;
using carpool.Services.CaptainServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace carpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaptainController:ControllerBase
    {
        private readonly ICaptainService _captainService;
        public CaptainController(ICaptainService captainService)
        {
            _captainService = captainService;
        }


        [HttpPost]  
        [Route("CaptainLogin")]  
        public async Task<IActionResult> Login([FromBody] UserLogin model)  
        {  
            string key ="Roses are red Violets are blue, White wine costs less, Than dinner for two. xDDDD" ;
            var captain = await _captainService.GetCaptain(model.UserEmail);  
            
            if (captain != null && BCrypt.Net.BCrypt.Verify(model.UserPassword, captain.Passwords) == true)  
            {  
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

        [HttpGet("AllCaptains")]
        public async Task<IActionResult> AllCaptains()
        {
            try
            {
                var data = await _captainService.AllCaptains();
                return Ok(data);
            }
            
            catch (Exception )
            {
                throw new Exception();
            }
        }

        [HttpPost("CaptainRegistration")]
        public async Task<IActionResult> CreateCaptain(CaptainModel captainModel)
        {
            try
            {
                var data = await _captainService.CreateCaptain(captainModel);
                return Ok(data);
            }
            
            catch (Exception )
            {
                throw new Exception();
            }
        }
        [HttpDelete("DeleteCaptain")]
        public async Task<IActionResult> DeleteCaptain(string email)
        {
            try
            {
                var data = await _captainService.DeleteCaptain(email);
                return Ok(data);
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }
    }
}