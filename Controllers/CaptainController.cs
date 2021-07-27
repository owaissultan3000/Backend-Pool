using carpool.Models;
using carpool.Services.CaptainServices;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("AllCaptains")]
        public IActionResult AllCaptains()
        {
            return Ok(_captainService.AllCaptains());
        }

        [HttpPost("AddCaptain")]
        public IActionResult CreateCaptain(CaptainModel captainModel)
        {
            return Ok(_captainService.CreateCaptain(captainModel));
        }
    }
}