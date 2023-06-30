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
    /// <summary>
    /// Controlador para los servicios referentes a la entidad Property
    /// </summary>
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

        /// <summary>
        /// Metodo para obtener todas las propiedades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _properties = await _propertyService.GetProperties();
            var response = new APIResponse<IEnumerable<PropertyDTO>>(_properties);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para obtener las propiedadas filtradas por los parametros
        /// </summary>
        /// <param name="name">Nombre de la propeidad</param>
        /// <param name="address">Direcion</param>
        /// <param name="idOwner">Codigo de propietario</param>
        /// <param name="price">Precio de la propiedad</param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> Get([FromQuery] string? name, [FromQuery] string? address, [FromQuery] int? idOwner, [FromQuery] decimal? price)
        {
            var _properties = await _propertyService.GetProperties(name,idOwner,price,address);
            var response = new APIResponse<IEnumerable<PropertyDTO>>(_properties);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para guardar propiedades
        /// </summary>
        /// <param name="obj">
        ///     Request de prpiedad en el cual tambien puede ir la informacion del propietario para guardar un propietario nuevo
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreatePropertyDTO obj)
        {
            var _property = await _propertyService.InsertPropertyAsync(obj);
            var response = new APIResponse<CreatePropertyDTO>(_property);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para actualizar la propiedad
        /// </summary>
        /// <param name="obj">
        ///  Este metodo solo permite actualizar el precio
        /// </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromForm] UpdatePropertyDTO obj)
        {
            var _property = await _propertyService.UpdatePropertyAsync(obj);
            var response = new APIResponse<UpdatePropertyDTO>(_property);
            return Ok(response);
        }
    }
}