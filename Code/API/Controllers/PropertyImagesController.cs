using Core.DTO.PropertyImage;
using Core.Interfaces.Services;
using Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreatePropertyImageDTO obj)
        {
            var _propertyImage = await _propertyImageService.InsertPropertyImageAsync(obj);
            var response = new APIResponse<CreatePropertyImageDTO>(_propertyImage);
            return Ok(response);
        }
    }
}
