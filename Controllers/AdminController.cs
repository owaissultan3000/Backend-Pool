using System;
using System.Threading.Tasks;
using carpool.Models;
using carpool.Services.AdminServices;
using carpool.Services.CaptainServices;
using carpool.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace carpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ICaptainService _captainService;
        private readonly IUserService _userServices;
        private readonly IAdminServices _adminServices;
        private readonly IConfiguration _configuration;

        public AdminController(ICaptainService captainService,IConfiguration configuration, IUserService userServices,IAdminServices adminServices)
        {
            _captainService = captainService;
            _userServices = userServices;
            _adminServices = adminServices;
            _configuration = configuration;
        }
        [Authorize]
        [HttpGet("AllCaptains")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> AllCaptains()
        {
            try
            {
                var data = await _adminServices.AllCaptains();
                return Ok(data);
            }
            
            catch (Exception )
            {
                throw new Exception();
            }
        }

        [Authorize]
        [HttpPost("CaptainRegistration")]
        public async Task<IActionResult> CreateCaptain(CaptainModel captainModel)
        {
            try
            {
                var data = await _adminServices.CreateCaptain(captainModel);
                return Ok(data);
            }
            
            catch (Exception )
            {
                throw new Exception();
            }
        }

        [Authorize]
        [HttpDelete("DeleteCaptain")]
        public async Task<IActionResult> DeleteCaptain(string email)
        {
            try
            {
                var data = await _adminServices.DeleteCaptain(email);
                return Ok(data);
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }

        [HttpGet("AllUsers")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> AllUsers()
        {
             try
            {
                var users = await _adminServices.AllUsers();
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

        [HttpPost("AdminRegistration")]
        public async Task<IActionResult> CreateAdmin(AdminModel adminModel)
        {
            try
            {
                var data = await _adminServices.CreateAdmin(adminModel);
                return Ok(data);
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }

        [HttpGet("GetAdmin")]
        public async Task<IActionResult> GetAdmin(string email)
        {
            try
            {
                var data = await _adminServices.GetAdmin(email);
                return Ok(data);
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }

        [HttpDelete("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(string email)
        {
            try
            {
                var data = await _adminServices.DeleteAdmin(email);
                return Ok(data);
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }

        [HttpGet("ViewAvailableRides")]
        public async Task<IActionResult> ViewAvailableRides()
        {
            try
            {
                var data = await _adminServices.ViewAvailableRides();
                return Ok(data);
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }





        
    }
}