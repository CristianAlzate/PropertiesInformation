using Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
           _config = config;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDTO objDTO)
        {
            if (objDTO.ValidateUser())
            {
                return Ok(new { Token = objDTO.GenerateToken(_config.GetSection("JWT:Key").Value) });
            }
            return NotFound("Usuario o contraseña invalida");
        }

        
    }
}
