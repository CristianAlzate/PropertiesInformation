using Core.DTO.PropertyImage;
using Core.DTO.PropertyTrace;
using Core.Interfaces.Services;
using Core.Wrappers;
using Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTracesController : ControllerBase
    {
        private readonly IPropertyTraceService _propertyTraceService;
        public PropertyTracesController(IPropertyTraceService propertyTraceService)
        {
            _propertyTraceService = propertyTraceService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreatePropertyTraceDTO obj)
        {
            var _propertyTrace = await _propertyTraceService.InsertPropertyTraceAsync(obj);
            var response = new APIResponse<CreatePropertyTraceDTO>(_propertyTrace);
            return Ok(response);
        }
    }
}
