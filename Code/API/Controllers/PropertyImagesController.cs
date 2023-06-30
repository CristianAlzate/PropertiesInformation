using Core.DTO.PropertyImage;
using Core.Interfaces.Services;
using Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controlador para los servicios referentes a la entidad PropertyImage
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly IPropertyImageService _propertyImageService;
        public PropertyImagesController(IPropertyImageService propertyImageService)
        {
            _propertyImageService = propertyImageService;
        }

        /// <summary>
        /// Metodo para insertar imagenes de una propiedad
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreatePropertyImageDTO obj)
        {
            var _propertyImage = await _propertyImageService.InsertPropertyImageAsync(obj);
            var response = new APIResponse<CreatePropertyImageDTO>(_propertyImage);
            return Ok(response);
        }
    }
}
