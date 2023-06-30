using AutoMapper;
using Core.DTO.Property;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _properties = await _propertyService.GetProperties();
            var response = new APIResponse<IEnumerable<PropertyDTO>>(_properties);
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Get([FromQuery] string? name, [FromQuery] string? address, [FromQuery] int? idOwner, [FromQuery] decimal? price)
        {
            var _properties = await _propertyService.GetProperties(name,idOwner,price,address);
            var response = new APIResponse<IEnumerable<PropertyDTO>>(_properties);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreatePropertyDTO obj)
        {
            var _property = await _propertyService.InsertPropertyAsync(obj);
            var response = new APIResponse<CreatePropertyDTO>(_property);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] UpdatePropertyDTO obj)
        {
            var _property = await _propertyService.UpdatePropertyAsync(obj);
            var response = new APIResponse<UpdatePropertyDTO>(_property);
            return Ok(response);
        }
    }
}