using Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    /// <summary>
    /// Controlador para la parte de seguridad de usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
           _config = config;
        }


        /// <summary>
        /// Metodo de autenticacion
        /// </summary>
        /// <param name="objDTO">
        ///     User = Usuario ingresado
        ///     Password = Contraseña ingresada
        /// </param>
        /// <returns>Token = token de autorizacion</returns>
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
