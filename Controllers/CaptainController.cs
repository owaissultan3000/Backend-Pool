using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using carpool.Models;
using carpool.Services.CaptainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace carpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaptainController:ControllerBase
    {
        private readonly ICaptainService _captainService;
        private readonly IConfiguration _configuration; 
        public CaptainController(ICaptainService captainService,IConfiguration configuration)
        {
            _captainService = captainService;
            _configuration = configuration;
        }


        [HttpPost]  
        [Route("CaptainLogin")]  
        public async Task<IActionResult> Login([FromBody] UserLogin model)  
        {  
            IActionResult response = Unauthorized();

            Captain captain = await _captainService.GetCaptain(model.UserEmail);  
            
            if (captain != null && BCrypt.Net.BCrypt.Verify(model.UserPassword, captain.Passwords) == true)  
            {  
                    var tokenString = GenerateJSONWebToken(captain);
                     response = Ok(new { token = tokenString });
             
            }
            return response;
        }     

        private string GenerateJSONWebToken(Captain userInfo)
             {
                 var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                 var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                 var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                   _configuration["Jwt:Issuer"],
                   null,
                   expires: DateTime.Now.AddMinutes(120),
                   signingCredentials: credentials);
                 return new JwtSecurityTokenHandler().WriteToken(token);
             }
       
       
        

        [Authorize]
        [HttpPost("CreateRide")]
        public async Task<IActionResult> CreateRide(CreateRideModel rideModel)
        {
            try
            {
                var data = await _captainService.CreateRide(rideModel);
                return Ok(data);

            }
            catch (Exception )
            {
                throw new Exception();
            }

        }
    }
}